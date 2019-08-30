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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.OverlapCircle(feetPos.position,checkRadius,groundLayer);
        if(onGround == true){
            animator.SetBool("Jumping",false);
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
        }
        if ((Input.GetKeyDown(KeyCode.X))&& onGround ==true && pm.isWall==false){ 
            
            animator.SetBool("Jumping",true);  
            animator.SetBool("Fall",false);
            rb.velocity = Vector2.up * jumpforce;
            jumping= true;
        }
        if  ((Input.GetKey(KeyCode.X)) && jumping==true && pm.isWall==false){
            if(jumpTimeCounter > 0){
                animator.SetBool("Jumping",true);  
                animator.SetBool("Fall",false);
                rb.velocity = Vector2.up * jumpforce;
                jumpTimeCounter -= Time.deltaTime;
            }
        }
        if  (Input.GetKeyUp(KeyCode.X)){
            firstTime=true;
            jumping = false;
        }
    }
}
