using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{
    public float knockbackforcex;
    public GameObject staminaSlider;
    public float stamina=1;
    public float knockbackforcey;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public int hearths;
    public int intialhearts=6;
    [SerializeField] private float invulnerableTimeCounter=0;
    public SpriteRenderer spriteRendHearth;
    public Sprite[] spriteHearths;
    [SerializeField] private float invulnerableTime;
    public bool invulnerability;
    public float checkRadius;
    public bool onHazard;
    public bool onHp;
    [SerializeField]private float timer =0;
    [SerializeField] private float flashTime=0.2f;
    public LayerMask hazardLayer;
    public LayerMask hpLayer;
    private Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        hearths = intialhearts;
        rb = GetComponent<Rigidbody2D>();
        sr= GetComponent<SpriteRenderer>();
        staminaSlider = GameObject.FindGameObjectWithTag("Stamina");
    }
    // Update is called once per frame
    void Update()
    {
        staminaSlider.GetComponent<Slider>().value=stamina;
        onHazard = Physics2D.OverlapCircle(transform.position,checkRadius,hazardLayer);
        onHp = Physics2D.OverlapCircle(transform.position,checkRadius*2.5f,hpLayer);
        if(onHazard == true){
            if(hearths>0 && invulnerability == false){
                col = Physics2D.OverlapCircle(transform.position,checkRadius,hazardLayer);
                float dot = Vector2.Dot(transform.right.normalized,col.gameObject.transform.right);
                Debug.Log(dot);
                if(dot < -0.998){
                    rb.AddForce(new Vector3(transform.position.x+ knockbackforcex ,transform.position.y,transform.position.z));
                    rb.velocity = Vector2.up * knockbackforcey;
                   // Debug.Log("izquierda");
                }
                else
                {
                    rb.AddForce(new Vector3(transform.position.x- knockbackforcex,transform.position.y,transform.position.z));
                    rb.velocity = Vector2.up * knockbackforcey;
                  //  Debug.Log("derecha");
                }
                
                spriteRendHearth.sprite = spriteHearths[hearths-1];
                hearths--;
                invulnerability =true;
               // Debug.Log("soy Invulnerable");
            }    
        }
        if(onHp == true && hearths>0){
            col = Physics2D.OverlapCircle(transform.position,checkRadius*2.5f,hpLayer);
            Destroy(col.gameObject);
            if(hearths<intialhearts){
                hearths++;
                spriteRendHearth.sprite = spriteHearths[0];
            }
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
            }
            if (timer >= flashTime){
                if(sr.enabled == true){
                    sr.enabled = false;
                    timer=0;
                }
                else{
                    sr.enabled = true;
                    timer=0;
                }
            }
        }
        else{
            timer=0;
            sr.enabled = true;
        }
    }

    public void TakeDamage()
    {
        if(hearths>0 && invulnerability == false)
        {
            rb.AddForce(new Vector3(transform.position.x- knockbackforcex,transform.position.y,transform.position.z));
            rb.velocity = Vector2.up * knockbackforcey;
            spriteRendHearth.sprite = spriteHearths[hearths-1];
            hearths--;
            invulnerability =true;
        }
    }
}
