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
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void OnCollisionEnter2D (Collision2D enemy){
        if(enemy.gameObject.tag =="Enemy"){
            Debug.Log("Daño BALAAAAA  "+damage);
            enemy.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else{
            Destroy(gameObject); 
        }
    }
}
