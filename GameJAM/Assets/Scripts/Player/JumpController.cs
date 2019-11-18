using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public bool onGround;
    private Rigidbody2D rb;
    public float jumpforce;
    public Transform feetPos;
    public float jumpTimeCounter;
    public float jumpTime;
    public float checkRadius;
    public LayerMask groundLayer;
    public bool jumping;

    private Animator animator;
    private PlayerMovement pm;
    public bool firstTime=true;
    public AudioSource jumpSound;
    public bool playSound;
    [SerializeField] private float groundRangeX;
    [SerializeField] private float groundRangeY;

    [SerializeField] private bool allowWallJump;

    // Start is called before the first frame update
    void Start()
    {
        allowWallJump=true;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.OverlapBox(feetPos.position,new Vector2(groundRangeX,groundRangeY),0,groundLayer);
        if(onGround == true){
            animator.SetBool("Jumping",false);
            playSound=true;
            animator.SetBool("Fall",true);
            animator.SetBool("OnAir",false);
            if(firstTime==true)
            {
                animator.SetBool("Fall",true);
                firstTime=false;
            }
            else
                animator.SetBool("Fall",false);
            jumpTimeCounter = jumpTime;
        }
        else{
            animator.SetBool("OnAir",true);
            firstTime=true;
        }
        if ((Input.GetKeyDown(KeyCode.X))&& (onGround ==true || pm.isWall==true)){ 
            animator.SetBool("Jumping",true);  
            animator.SetBool("Fall",false);
            if(pm.isWall==false)
                rb.velocity = Vector2.up * jumpforce;
            else if(allowWallJump==true)
            {
                rb.velocity = Vector2.up * jumpforce*2;
                transform.Translate(-1f,0,0);
            }
            jumping= true;
            allowWallJump=false;
        }
        if  ((Input.GetKey(KeyCode.X)) && jumping==true && pm.isWall==false){
            if(jumpTimeCounter > 0){
                if(playSound==true)
                {
                    jumpSound.Play();
                    playSound=false;
                }
                animator.SetBool("Jumping",true);  
                animator.SetBool("Fall",false);
                rb.velocity = Vector2.up * jumpforce;
                jumpTimeCounter -= Time.deltaTime;
            }
        }
        if  (Input.GetKeyUp(KeyCode.X)){
            if(pm.isWall==true)
                rb.velocity=new Vector2(0,0);
            firstTime=true;
            jumping = false;
            allowWallJump=true;
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(feetPos.position,new Vector3(groundRangeX,groundRangeY,1));
    }
}
