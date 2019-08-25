using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SecretArea : MonoBehaviour
{
    float alphaValue = 1f;
    public Tilemap map;
    public float dissapearRate = 1f;
    bool playerEntered = false;

    public bool toggleWall = false;

    // Update is called once per frame
    void Update()
    {
        if(playerEntered)
        {
            alphaValue -= Time.deltaTime *dissapearRate;

            if(alphaValue <= 0 )
            alphaValue = 0;

            map.color = new Color(map.color.r,map.color.g,map.color.b,alphaValue);;
        }
        else
        {
            
            alphaValue += Time.deltaTime *dissapearRate;

            if(alphaValue >= 1 )
            alphaValue = 1;

            map.color = new Color(map.color.r,map.color.g,map.color.b,alphaValue);;
        
        }
    }

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.CompareTag("Player"))
        {
            playerEntered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && toggleWall)
        {
            playerEntered = false;
        }
    }
}
