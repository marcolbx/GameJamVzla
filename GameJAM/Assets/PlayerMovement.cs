using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public JumpController jumpController;
    public float wallCheckX;
    public float wallCheckY;
    public Transform wallLeft;
    public Transform wallRight;
    public float transitionTimer=0.2f;
    [SerializeField]
    private float walkingSpeed=1f;
    public float horizontal=1;
    public bool isWallLeft;
    public bool isWallRight;
    private bool wasOnWall;
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    private float initialGravity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialGravity = rb.gravityScale;
        jumpController = GetComponent<JumpController>();
    }

    // Update is called once per frame
    void Update()
    {
        isWallLeft = Physics2D.OverlapBox(wallLeft.position,new Vector2(wallCheckX,-wallCheckY),0,groundLayer);
        isWallRight = Physics2D.OverlapBox(wallRight.position,new Vector2(wallCheckX,wallCheckY),0,groundLayer);
        if(transitionTimer <=0.2){
            transitionTimer +=Time.deltaTime;
        }
        if(isWallLeft || isWallRight){
            rb.gravityScale = initialGravity/5;
            if(!jumpController.onGround && jumpController.jumpTimeCounter<jumpController.jumpTime/2)
                rb.velocity = Vector2.down;
            wasOnWall = true;
        }
        else{
            rb.gravityScale = initialGravity;
            if(wasOnWall == true){
                jumpController.jumping=true;
                jumpController.jumpTimeCounter=jumpController.jumpTime;
            }
            wasOnWall = false;
        }
        if(Input.GetKey(KeyCode.RightArrow) && !isWallRight){
            horizontal=1;
            transform.Translate(walkingSpeed* Time.deltaTime,0,0);
            transform.eulerAngles = new Vector3 (0,0,0);
        }
        else if(Input.GetKey(KeyCode.LeftArrow) && !isWallLeft){
            horizontal =-1;
            transform.Translate(walkingSpeed* Time.deltaTime*horizontal,0,0);
        }
        
    }
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(wallRight.position,new Vector3(wallCheckX,wallCheckY,1));
        Gizmos.DrawWireCube(wallLeft.position,new Vector3(wallCheckX,wallCheckY*-1,1));
    }
}
