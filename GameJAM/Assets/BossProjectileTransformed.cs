using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileTransformed : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public Sprite[] letters;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        int randomLetter = Random.Range(0,24);
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = letters[randomLetter];
        
        /* 
        int randomx = Random.Range(-3,3);
        int randomy = Random.Range(6,8);
        Vector2 direction = new Vector2(0,randomy);
        rigidbody.velocity = direction;
        */
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Destroy(this.gameObject,5f);
    }
}
