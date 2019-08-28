using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Sprite[] doors;
    private SpriteRenderer sr;
    private BoxCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        sr= GetComponent<SpriteRenderer>();
        col=GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor(){
        sr.sprite=doors[1];
        col.enabled=false;
    }
}
