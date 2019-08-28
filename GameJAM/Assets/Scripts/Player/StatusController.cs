using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{
    private int level=1;
    public float proportionExp=1f;
    private float experience=0;
    public float knockbackforcex;
    public GameObject staminaSlider;
    public GameObject experienceSlider;
    public float stamina=1;
    public float knockbackforcey;
    private Rigidbody2D rb;
    public int hearths;
    public int intialhearts=5;
    [SerializeField] private float invulnerableTimeCounter=0;
    public SpriteRenderer spriteRendHearth;
    public Sprite[] spriteHearths;
    [SerializeField] private float invulnerableTime;
    public bool invulnerability;
    public float checkRadius;
    public bool onHazard;
    private bool onLift;
    public bool onCollectable;
    private float newExperience=0;
    [SerializeField]private float timer =0;
    [SerializeField] private float flashTime=0.2f;
    public LayerMask hazardLayer;
    public LayerMask CollectableLayer;
    public bool restore=false;
    public int staminaRecover=50;
    private Collider2D col;
    private SpriteRenderer[] sprites;
    private InventoryController inventory;
    private Animator animator;
    public LayerMask liftLayer;
    public float previousGravity;
    public AudioSource playerHurtSound;
    public AudioSource playerCoin;
    public AudioSource playerHeal;
    public AudioSource playerPoison;
    // Start is called before the first frame update
    void Start()
    {
        hearths = intialhearts;
        rb = GetComponent<Rigidbody2D>();
        staminaSlider = GameObject.FindGameObjectWithTag("Stamina");
        experienceSlider = GameObject.FindGameObjectWithTag("Experience");
        sprites = gameObject.GetComponentsInChildren<SpriteRenderer>();
        inventory = gameObject.GetComponent<InventoryController>();
        animator = gameObject.GetComponent<Animator>();
        previousGravity=rb.gravityScale;
    }
    // Update is called once per frame
    void Update()
    {
        if(inventory.GetPower()==false && stamina+(Time.deltaTime/staminaRecover)<=1){
            stamina+=Time.deltaTime/staminaRecover;
        }
        experience = Mathf.Lerp(experience,newExperience,4*Time.deltaTime);
        experienceSlider.GetComponent<Image>().fillAmount =experience;
        staminaSlider.GetComponent<Slider>().value=stamina;
        onHazard = Physics2D.OverlapCircle(transform.position,checkRadius,hazardLayer);
        onLift = Physics2D.OverlapCircle(transform.position,checkRadius,liftLayer);
        onCollectable = Physics2D.OverlapCircle(transform.position,checkRadius,CollectableLayer);
        Debug.Log(invulnerability);
        if(onHazard == true && invulnerability==false){
            if(hearths>0){
                col = Physics2D.OverlapCircle(transform.position,checkRadius,hazardLayer);
                float dot = Vector2.Dot(transform.right,col.gameObject.transform.right);
                if(dot < -0.998){
                    rb.AddForce(new Vector3(knockbackforcex ,0,0));
                    rb.velocity = Vector2.up * knockbackforcey;
                    Debug.Log("izquierda");
                }
                else
                {
                    rb.AddForce(new Vector3(-knockbackforcex,0,0));
                    rb.velocity = Vector2.up * knockbackforcey;
                    Debug.Log("derecha");
                }
                hearths--;

                spriteRendHearth.sprite = spriteHearths[hearths];
                invulnerability =true;
                playerHurtSound.Play();
            }    
        }
        if(onCollectable == true && hearths>0){
            col = Physics2D.OverlapCircle(transform.position,checkRadius*1.01f,CollectableLayer);
            if(col.tag==("Hp")){
                if(hearths<intialhearts){
                    playerHeal.Play();
                    hearths++;
                    spriteRendHearth.sprite = spriteHearths[hearths];
                }
                Destroy(col.gameObject);
            }
            else if(col.tag==("Poison")){
                playerPoison.Play();
                    hearths--;
                    spriteRendHearth.sprite = spriteHearths[hearths];
                    Destroy(col.gameObject);
            }
            else if(col.tag==("Collectable"))
            {
                playerCoin.Play();
                col.gameObject.GetComponent<Money>().Obtain();
                float money= col.gameObject.GetComponent<Money>().amount;
                inventory.money +=money;
            }
            else if(col.tag==("Key"))
            {
                inventory.keys++;
                Destroy(col.gameObject);
            }
            else if(col.tag == "WeaponYoyo"){
                inventory.yoyoWeapon =true;
                Destroy(col.gameObject);

            }
            else if(col.tag == "WeaponSlingShot"){
                inventory.slingshotWeapon=true;
            }
            else if(col.tag == "WeaponGlass"){
                inventory.glassWeapon=true;
            }
        }
        if (onLift==true){
            animator.SetBool("Lift",true);
            rb.gravityScale=5;
        }
        else{
            animator.SetBool("Lift",false);
            rb.gravityScale=previousGravity;
        }
        if (hearths<=0){
            Destroy(this.gameObject);
        }
        if(invulnerability == true){
            timer += Time.deltaTime;
            invulnerableTimeCounter +=Time.deltaTime;
            if(invulnerableTimeCounter>=invulnerableTime){
                invulnerability = false;
                invulnerableTimeCounter = 0;
                restore=true;
            }
            if (timer >= flashTime){
                for(int i=0;i<sprites.Length;i++){
                    if(sprites[i].enabled== true){
                        sprites[i].enabled = false;
                        timer=0;
                    }
                    else{
                        if(animator.GetBool("SlingShot")==true)
                        {
                            if (sprites[i].tag!="Yoyo")
                            {
                                sprites[i].enabled = true;
                                timer=0;
                            }
                        } else if(animator.GetBool("Yoyo")==true){
                            if (sprites[i].tag!="SlingShot")
                            {
                                sprites[i].enabled = true;
                                timer=0;
                            }
                        }
                        else {
                            if(sprites[i].tag!="SlingShot" && sprites[i].tag!="Yoyo")
                            {
                                sprites[i].enabled = true;
                                timer=0;
                            }
                        }
                    }
                }
            }
        }
        else if(restore == true){
            timer=0;
            for(int i=0;i<sprites.Length;i++){
                if(animator.GetBool("SlingShot")==true)
                {
                    if (sprites[i].tag!="Yoyo")
                    {
                        sprites[i].enabled = true;
                    }
                }
                else if(animator.GetBool("Yoyo")==true)
                {
                    if (sprites[i].tag!="SlingShot")
                    {
                        sprites[i].enabled = true;
                    }
                }
                else{
                    if(sprites[i].tag!="SlingShot" && sprites[i].tag!="Yoyo")
                    {
                       sprites[i].enabled = true; 
                    }
                }
            }
            restore = false;
        }
    }

    public void TakeDamage()
    {
        if(hearths>0 && invulnerability == false)
        {
            rb.AddForce(new Vector3(transform.position.x- knockbackforcex,transform.position.y,transform.position.z));
            rb.velocity = Vector2.up * knockbackforcey;
            hearths--;
            spriteRendHearth.sprite = spriteHearths[hearths];
            invulnerability =true;
        }
    }

    public void ObtainExp(float exp){
        exp=exp/(level*proportionExp*100);
        if(newExperience + exp >=1){
            newExperience = (newExperience+exp)-1;
            proportionExp -= proportionExp/10;
        }
        else{
            newExperience +=exp;
        }
    }
}
