using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowEnemyProjectile : MonoBehaviour
{
    Vector2 moveDirection;
    Transform player;
    public float speed = 5f;
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        player = PlayerManager.instance.player.transform;

        moveDirection = (player.transform.position - transform.position).normalized * speed;
        rigidbody.velocity = new Vector2(moveDirection.x,moveDirection.y);
        Destroy(gameObject,4f);
        
    }

    /* private void OnTriggerEnter2D(Collider2D other) {
    if(other.CompareTag("Player") && !other.isTrigger) 
    other.gameObject.GetComponent<StatusController>().TakeDamage();   
    }*/

}
