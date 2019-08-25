using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] public float amount = 100f;
    [SerializeField] private float aliveTimer = 5f;
    private Animator animator;
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();

        int random = Random.Range(-3,3);
        if(Mathf.Abs(random) <=1)
        random +=1;
        Vector2 direction = new Vector2(random, 3 * Mathf.Abs(random /2));
        rigidbody.velocity = direction;
    }

    // Update is called once per frame
    void Update()
    {
        if(aliveTimer <= 0)
        Destroy(gameObject);

        aliveTimer -= Time.deltaTime;

        animator.speed = (5 / aliveTimer); 
        
    }

    public void Obtain()
    {
        Destroy(gameObject);
    }
}
