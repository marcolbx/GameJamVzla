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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.OverlapCircle(feetPos.position,checkRadius,groundLayer);
        if(onGround == true){
            jumpTimeCounter = jumpTime;
        }
        if (Input.GetKeyDown(KeyCode.X) && onGround ==true){   
            rb.velocity = Vector2.up * jumpforce;
            jumping= true;
        }
        if  (Input.GetKey(KeyCode.X) && jumping==true){
            if(jumpTimeCounter > 0){
                rb.velocity = Vector2.up * jumpforce;
                jumpTimeCounter -= Time.deltaTime;
            }
        }
        if  (Input.GetKeyUp(KeyCode.X)){
            jumping = false;
        }
    }
}
