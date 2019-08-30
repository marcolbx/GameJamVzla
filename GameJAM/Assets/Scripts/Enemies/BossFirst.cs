﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossFirst : Enemy
{
    private SpriteRenderer[] spriteRenderers;
    private bool move =false;
    public GameObject projectile;
    public GameObject inkEnemy;
    public Slider slider;
    public GameObject table;
    public GameObject healthBar;
    public GameObject boss2ndForm;
    public GameObject background;
    [SerializeField] private float activationDistance =3f;
    Transform player;
    //public AudioSource letterAtk;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderers = gameObject.GetComponentsInChildren<SpriteRenderer>();
        player = PlayerManager.instance.player.transform;
       // InstantiateProjectile();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

        if(Vector3.Distance(transform.position,player.position) < 5f)
        {
            animator.SetTrigger("Idle");
            healthBar.SetActive(true);
        }
        
        if(move==true)
        InsideSpriteMask();
        if(move == false)
        DisableSpriteMask();

        slider.value = health;

        if(health<= 0)
        {
            table.SetActive(false);
            healthBar.SetActive(false);
            boss2ndForm.SetActive(true);
            background.GetComponent<Animator>().SetTrigger("Change");
        }
        
        
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
        GameObject bullet = Instantiate(projectile,transform.position,Quaternion.identity);
    }

    public void InstantiateInkEnemy()
    {
        GameObject enemy = Instantiate(inkEnemy,transform.position,Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        
        Gizmos.DrawWireSphere(transform.position, activationDistance);
    }
}
