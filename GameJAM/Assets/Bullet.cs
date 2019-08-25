using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
     public float speed= 20f;
    public float damage =1f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        transform.Translate(transform.up *Time.deltaTime);
        rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    
    void OnTriggerEnter2D (Collider2D enemy){
        if(enemy.tag =="Enemy"){
            enemy.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag != "Enemy"){
            Destroy(gameObject);
        }
    }
}
