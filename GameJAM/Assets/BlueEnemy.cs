using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemy : Enemy
{
     private Vector2 targetX; // solo en la X position
    [SerializeField] private float minDistance = 4f;
    [SerializeField] private float normalSpeed = 1.4f;
    private AudioSource audioSource;
    private bool soundPlayed = false;
    public GameObject implosion;
     Vector3 handsTogether;
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
        handsTogether = new Vector3(transform.position.x,transform.position.y +1f,transform.position.z);
        base.Update();
        targetX = new Vector2(target.position.x,this.transform.position.y);
        if(health > 0)
        {
            if(Vector2.Distance(this.transform.position,target.position) < minDistance +2f)
            {

        //    transform.position = Vector2.MoveTowards(transform.position,targetX,speed * Time.deltaTime);
            PursuitModeState();
            }
            else if(Vector2.Distance(this.transform.position,target.position) > minDistance *2f)
            {
                ChillModeState();
            }
        }
    }

    void PursuitModeState()
    {
        if(soundPlayed == false)
        {
            audioSource.Play();
            soundPlayed = true;
        }
        
        animator.speed = 1.0f;
        animator.ResetTrigger("Idle");
        animator.SetTrigger("Pursuit");
        speed = 2.6f;
        /* 
        if(target.position.x < animator.transform.position.x && Vector2.Distance(this.transform.position,target.position) > 1f)
        {
                animator.transform.eulerAngles = new Vector3(0,0,0);
        }
        
        else if(target.position.x >= animator.transform.position.x && Vector2.Distance(this.transform.position,target.position) > 1f)
        {

                animator.transform.eulerAngles = new Vector3(0,180,0);
        }
        */
        
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
        renderers[0].sprite = evilSprites[0];
        renderers[1].sprite = evilSprites[1];
        renderers[2].sprite = evilSprites[2];
        renderers[3].sprite = evilSprites[3];
        renderers[4].sprite = evilSprites[4];
        renderers[5].sprite = evilSprites[5];
    }

    public void InstantiateImplosion()
    {
       
        GameObject bullet = Instantiate(implosion, handsTogether,Quaternion.identity );
        bullet.transform.SetParent(this.transform);
        Destroy(bullet,1f);
    }

}
