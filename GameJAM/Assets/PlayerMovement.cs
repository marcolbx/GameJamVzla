using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    private float initialGravity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialGravity = rb.gravityScale;
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
            rb.velocity = Vector2.down;
        }
        else{
            rb.gravityScale = initialGravity;
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
