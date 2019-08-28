using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkEnemy : Enemy
{
    Vector2 moveDirection;
    public Collider2D collider;

    private bool onWall = false;
    public Transform wallTrigger;
    [SerializeField] private float triggerRadius = 1f;
    public LayerMask wall;
    bool movingRight = false;
    bool atk = false;
    float timer = 5f;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
       // moveDirection = (target.transform.position - transform.position).normalized * speed;
       
        if(target.position.x < animator.transform.position.x)
        {
                animator.transform.eulerAngles = new Vector3(0,0,0);
                movingRight = false;
                moveDirection = Vector2.left.normalized * speed;
      //  rigidbody.velocity = new Vector2(moveDirection.x,transform.position.y);
        }
        
        else
        {

                animator.transform.eulerAngles = new Vector3(0,180,0);
                movingRight = true;
                moveDirection = Vector2.right.normalized * speed;
     //   rigidbody.velocity = new Vector2(moveDirection.x,transform.position.y);
        }
        StartCoroutine(WaitEntering());
    }

    // Update is called once per frame
    override protected void Update()
    {
        if(health > 0)
        {
            timer -= Time.deltaTime;
            if(atk == true){

            
       // base.Update();
     //  moveDirection = (target.transform.position - transform.position).normalized * speed;
       rigidbody.velocity = new Vector2(moveDirection.x,transform.position.y);

       onWall = Physics2D.OverlapCircle(wallTrigger.position, triggerRadius,wall);
        Debug.Log(onWall);
            if(onWall == true)
            {
                if(movingRight == true)
                {
               
              // moveDirection = (target.transform.position - transform.position).normalized * speed;
               
               transform.eulerAngles = new Vector3(0,0,0);
               moveDirection = Vector2.left * speed;
               rigidbody.velocity = new Vector2(moveDirection.x,transform.position.y);
                movingRight = false;
                onWall = false;
                }
                else
                {
               
             //  moveDirection = (target.transform.position - transform.position).normalized * speed;
                
                transform.eulerAngles = new Vector3(0,180,0);
                moveDirection = Vector2.right.normalized * speed;
                rigidbody.velocity = new Vector2(moveDirection.x,transform.position.y);
                movingRight = true;
                onWall = false;
                }
            }
        }
        if(timer<= 0)
        health = 0;
        }

       if(health <= 0 && oneTimedead == false )
        {
            Die();
            oneTimedead = true;
        }

        animator.SetFloat("Hp",health);

        if(hurtTimer <= 0)
        {
            ReturnNormalSprites();
            hurtTimer =0.5f; //Recordardcambiar arriba
        }

        if(hurt == true && hurtTimer > 0)
        {
            hurtTimer -= Time.deltaTime;
        }
       
    }

    public override void Die()
    {
        Debug.Log("DIE()");
        PlayerManager.instance.player.GetComponent<StatusController>().ObtainExp(this.experience);
        Destroy(gameObject,0.87f); // asi esta bien
    }

    public override void TakeDamage(float damage)
    {
        Debug.Log("Recibio " + damage +" de dano");
        this.health -= damage;
        hurtSound.Play();
        Hurt();
    }

    public override void Hurt()
    {
        /* 
        for (int i = 0; i <hurtSprites.Length; i++)
        {
            renderers[i].sprite = hurtSprites[i];
        }
        */
        hurt = true;
    }


    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Die();
        }
    }

    IEnumerator WaitEntering()
    {
        yield return new WaitForSeconds(0.5f);
        atk = true;
    }

    
}
