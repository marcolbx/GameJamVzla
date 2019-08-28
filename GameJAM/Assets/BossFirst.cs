using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFirst : MonoBehaviour
{
    private SpriteRenderer[] spriteRenderers;
    private bool move =false;
    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderers = gameObject.GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(move==true)
        InsideSpriteMask();
        if(move == false)
        DisableSpriteMask();
        
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
}
