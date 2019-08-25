using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected int   damage;
    [SerializeField] protected float speed;
    public Animator animator;
    protected Transform target;
    public Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        if(health <= 0 )
        Die();
    }

    public virtual void TakeDamage(float damage)
    {
        Debug.Log("Recibio " + damage +" de dano");
        this.health -= damage;
    }

    public virtual void PlayerLocation()
    {
        target = PlayerManager.instance.player.transform;
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
