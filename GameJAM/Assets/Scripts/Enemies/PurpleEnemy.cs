using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleEnemy : Enemy
{
   private Vector2 targetX; // solo en la X position
    [SerializeField] private float minDistance = 4f;
    [SerializeField] private float normalSpeed = 1.4f;
    private AudioSource audioSource;
    private bool soundPlayed = false;
    private bool movingRight = true;
    public Transform groundDetection;
    private Vector2 groundD; //Cambiar de Transform a Vector2

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        target = PlayerManager.instance.player.transform;
        targetX = new Vector2(target.position.x,this.transform.position.y);
        animator.SetFloat("Hp",health);

    }

    // Update is called once per frame
    override protected void Update()
    {
        base.Update();
        groundD = new Vector2(groundDetection.position.x,groundDetection.position.y);
        targetX = new Vector2(target.position.x,this.transform.position.y);

        if(health > 0)
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundD, Vector2.down,2f);
  

        if(groundInfo.collider == false)
        {
            if(movingRight == true)
            {
              //  Debug.Log("Entro en movingRight = true");
                animator.transform.eulerAngles = new Vector3(0,0,0);
                movingRight = false;
            }
            else
            {
               // Debug.Log("Entro en movingRight = false");
                animator.transform.eulerAngles = new Vector3(0,180,0);
                movingRight = true;
            }
        }
  
  /* 
        if(health > 0)
        {
            if(Vector2.Distance(this.transform.position,target.position) < minDistance)
            {

            transform.position = Vector2.MoveTowards(transform.position,targetX,speed * Time.deltaTime);
            PursuitModeState();
            }
            else
            {
                ChillModeState();
            }
        }
        */
    }

    void PursuitModeState()
    {
        if(soundPlayed == false)
        audioSource.Play();
        soundPlayed = true;
        animator.speed = 1.0f;
        animator.ResetTrigger("Idle");
        animator.SetTrigger("Pursuit");
        speed = 2f;
        if(target.position.x < animator.transform.position.x)
        {
                animator.transform.eulerAngles = new Vector3(0,0,0);
        }
        
        else
        {

                animator.transform.eulerAngles = new Vector3(0,180,0);
        }
        if(isEvil == true && hurt == false)
        {
            EvilSprites();
        }
    }

    void ChillModeState()
    {
        soundPlayed = false;
       // Debug.Log("ChillModeState");
        animator.ResetTrigger("Pursuit");
        speed = normalSpeed;
        animator.SetTrigger("Idle");
        animator.speed = 1.0f;
    }

        public void EvilSprites()
    {
        renderers[1].sprite = evilSprites[0];
        renderers[2].sprite = evilSprites[1];
        renderers[3].sprite = evilSprites[2];
    }
}

