using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public JumpController jumpController;
    public float wallCheckX;
    public float wallCheckY;
    public Transform wall;
    public float transitionTimer=0.5f;
    [SerializeField]
    private float walkingSpeed=1f;
    public float horizontal=1;
    public bool isWall;
    private bool wasOnWall;
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    private float initialGravity;
    public float gravityProportion;
    
    private float wallfly;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialGravity = rb.gravityScale;
        jumpController = GetComponent<JumpController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isWall = Physics2D.OverlapBox(wall.position,new Vector2(wallCheckX,wallCheckY),0,groundLayer);
        if(transitionTimer <=0.5){
            transitionTimer +=Time.deltaTime;
        }
        if(isWall){
            jumpController.jumpTimeCounter=jumpController.jumpTime;
            rb.gravityScale = initialGravity/gravityProportion;
            if(wasOnWall==false)
                rb.velocity=new Vector2(0,0);
            /*if(jumpController.jumpTimeCounter>0)
                rb.velocity=new Vector2(0,0);*/
            //if(!jumpController.onGround && jumpController.jumpTimeCounter<jumpController.jumpTime/2)
                //rb.velocity = Vector2.down;
            wasOnWall = true;
            animator.SetBool("Walking",false);
        }
        else{
            rb.gravityScale = initialGravity;
            if(wasOnWall == true){
                jumpController.jumping=true;
                jumpController.jumpTimeCounter=jumpController.jumpTime;
            }
            wasOnWall = false;
            Debug.Log("ya no estoy en pared");
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.eulerAngles = new Vector3 (0,0,0);
            if(!isWall){
                horizontal=1;
                transform.Translate(walkingSpeed* Time.deltaTime,0,0);
                animator.SetBool("Walking",true);
            }
            
        }
        else if(Input.GetKey(KeyCode.LeftArrow)){
            transform.eulerAngles = new Vector3 (0,180,0);
            if(!isWall){
                horizontal =-1;
                transform.Translate(walkingSpeed* Time.deltaTime,0,0);
                animator.SetBool("Walking",true);
            }
        }else{
            animator.SetBool("Walking",false);
        }
        
    }
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(wall.position,new Vector3(wallCheckX,wallCheckY,1));
    }
}
