using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSecond : Enemy
{
    private SpriteRenderer[] spriteRenderers;
    private bool move =false;
    public GameObject projectile;
    public GameObject inkEnemy;
    public Slider slider;
    private bool completeHealth = false;
    Vector3 pos;
    public Transform head;
    public GameObject healthBar;
    public GameObject particles;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderers = gameObject.GetComponentsInChildren<SpriteRenderer>();
        health = 1f;
        healthBar.SetActive(true);
        Instantiate(particles,transform.position,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(completeHealth == false)
        {
            health = Mathf.Lerp(health,25,Time.deltaTime * 0.35f);
            if(health >= 24)
            {
                health = 25;
                completeHealth = true;
            }
            
        }
        

        base.Update();


        slider.value = health;
        
    }

    public void InsideSpriteMask()
    {
        foreach (SpriteRenderer renderer in spriteRenderers)
        {
            renderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        }
    }

    public void DisableSpriteMask()
    {
        foreach (SpriteRenderer renderer in spriteRenderers)
        {
            renderer.maskInteraction = SpriteMaskInteraction.None;
        }
    }

    public void InstantiateProjectile()
    {
        float random = Random.Range(-5.5f,5.5f);
        float randomy = Random.Range(5.5f, 6.5f);
        pos = new Vector3(random,randomy,0);
        GameObject bullet = Instantiate(projectile,pos,Quaternion.identity);
    }

    public void InstantiateInkEnemy()
    {
        GameObject enemy = Instantiate(inkEnemy,transform.position,Quaternion.identity);
    }

    public override void Die()
    {
        Debug.Log("DIE()");
        PlayerManager.instance.player.GetComponent<StatusController>().ObtainExp(this.experience);
        GameObject explosion = Instantiate(PS_Explosion,head.position,Quaternion.identity);
        Destroy(gameObject,0.87f); // asi esta bien


    }
}
