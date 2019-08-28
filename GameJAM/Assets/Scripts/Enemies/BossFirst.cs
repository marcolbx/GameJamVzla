using System.Collections;
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
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderers = gameObject.GetComponentsInChildren<SpriteRenderer>();
       // InstantiateProjectile();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if(move==true)
        InsideSpriteMask();
        if(move == false)
        DisableSpriteMask();

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
        GameObject bullet = Instantiate(projectile,transform.position,Quaternion.identity);
    }

    public void InstantiateInkEnemy()
    {
        GameObject enemy = Instantiate(inkEnemy,transform.position,Quaternion.identity);
    }
}
