using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] public float health;
    [SerializeField] protected int   damage;
    [SerializeField] protected float experience;
    [SerializeField] protected float speed;
    public Animator animator;
    protected Transform target;
    public Rigidbody2D rigidbody;
    public GameObject PS_Explosion;
    protected bool oneTimedead = false;
    public Sprite[] hurtSprites;
    public Sprite[] normalSprites;
    public Sprite[] evilSprites;
    public SpriteRenderer[] renderers;
    [SerializeField] protected float hurtTimer =0.5f;
    protected bool hurt = false;
    [SerializeField] protected bool isEvil = true;
    public GameObject[] moneyToSpawn;
    public GameObject[] items;//0 Potion, 1 Bullets

    public AudioSource hurtSound;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    virtual protected void Update()
    {
        if(health <= 0 && oneTimedead == false )
        {
            Die();
            oneTimedead = true;
        }

        animator.SetFloat("Hp",health);

        if(hurtTimer <= 0)
        {
            ReturnNormalSprites();
            hurtTimer =0.5f; //Recordardcambiar arriba
        }

        if(hurt == true && hurtTimer > 0)
        {
            hurtTimer -= Time.deltaTime;
        }
        
    }

    public virtual void TakeDamage(float damage)
    {
        Debug.Log("Recibio " + damage +" de dano");
        this.health -= damage;
        hurtSound.Play();
        Hurt();
    }

    public virtual void PlayerLocation()
    {
        target = PlayerManager.instance.player.transform;
    }

    public virtual void Die()
    {
        Debug.Log("DIE()");
        PlayerManager.instance.player.GetComponent<StatusController>().ObtainExp(this.experience);
        GameObject explosion = Instantiate(PS_Explosion,transform.position,Quaternion.identity);
        Destroy(gameObject,0.87f); // asi esta bien


    }

    public virtual void Hurt()
    {
        for (int i = 0; i <hurtSprites.Length; i++)
        {
            renderers[i].sprite = hurtSprites[i];
        }
        hurt = true;
    }

    public virtual void ReturnNormalSprites()
    {
        for (int i = 0; i <normalSprites.Length; i++)
        {
            renderers[i].sprite = normalSprites[i];
        }
        hurt = false;
    }



    public virtual void DisableRigidbody()
    {
        rigidbody.Sleep();
        rigidbody.isKinematic = true;
    }

    public virtual void InstantiateMoneyItems()
    {
        Debug.Log("Instantiate MoneyItems");
        if(moneyToSpawn.Length>0)
    foreach (GameObject money in moneyToSpawn)
    {
        GameObject geld = Instantiate(money,transform.position,Quaternion.identity);
    }

    
    if(items.Length>0)
    {
        int random = Random.Range(0,4);
        GameObject item;
        if(random == 0)
         item = Instantiate(items[random],transform.position,Quaternion.identity);
    }
    
    }



}
