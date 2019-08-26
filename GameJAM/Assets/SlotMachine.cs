using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachine : Interactable
{
    public SpriteRenderer[] slotReelRenderers;
    public Sprite[] slotReelSprites;  //0 Enemy, 1 Hazard, 2 Money
    [SerializeField] bool isEvil = false;
    [SerializeField] private float speed =4f;
    private int random;
    [SerializeField] private float timer =3f;
    private int result;
    public GameObject[] enemies;
    public GameObject[] hazards;
    public GameObject chest;
    [SerializeField] private bool activated =false;
    private Collider2D collider;
    public Animator[] animators;
    public Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(activated == true)
        {
            if(timer>0)
            Randomize();

            if(timer<= 0 && isEvil)
            {
            slotReelRenderers[0].sprite = slotReelSprites[0]; //Enemies
            slotReelRenderers[1].sprite = slotReelSprites[0]; //Enemies
            slotReelRenderers[2].sprite = slotReelSprites[0]; //Enemies
            DisableCollider();
            AwakeRigidbody();

            activated = false;
            }
        

            else if (timer <= 0 && isEvil == false)
            {
                foreach (SpriteRenderer renderer in slotReelRenderers)
                {
                    renderer.sprite = slotReelSprites[random];
                    result = random;
                }

                DisableCollider();
                AwakeRigidbody();
                if(result == 2)
                Instantiate(chest,transform.position,Quaternion.identity);

                if(result == 0)
                foreach (GameObject enemy in enemies)
                {
                    Vector3 pos = new Vector3(transform.position.x,transform.position.y +1f,transform.position.z);
                    Instantiate(enemy,pos,Quaternion.Euler(0,0,0));
                }
                

                activated = false;

            }
        

         timer -= Time.deltaTime;
        }
    }

    public override void Action()
    {
        activated = true;
        foreach (Animator anim in animators)
        {
            anim.SetTrigger("action");
        }
    }

    void Randomize() 
    {
        random = Random.Range(0,3);

                int i = Random.Range(0,3);
                int j = Random.Range(0,3);
                int k = Random.Range(0,3);
                slotReelRenderers[0].sprite = slotReelSprites[i];
                slotReelRenderers[1].sprite = slotReelSprites[j];
                slotReelRenderers[2].sprite = slotReelSprites[k];
            
    }

    void DisableCollider()
    {
        collider.enabled = false;
    }

    void AwakeRigidbody()
    {
        rigidbody.WakeUp();
        int random = Random.Range(-3,3);
        if(Mathf.Abs(random) <=1)
        random +=1;
        Vector2 direction = new Vector2(random, 3 * Mathf.Abs(random+2));
        rigidbody.velocity = direction;
    }
}
