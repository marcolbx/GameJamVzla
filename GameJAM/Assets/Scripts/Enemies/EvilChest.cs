using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilChest : Enemy
{
    private bool pursuit = false;
    private Vector2 targetX; // solo en la X position
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    override protected void Update()
    {
        base.Update();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        Open();
    }

    public void Open()
    {
        animator.SetTrigger("atk");
    }

    public void PursuitMode()
    {
        pursuit = true;
    }

    public void DisableRigidbody()
    {
        rigidbody.Sleep();
        rigidbody.isKinematic = true;
    }

}
