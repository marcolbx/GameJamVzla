using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudTranslate : MonoBehaviour
{
    public float limitLet;
    public float initialRight;
    public float movementX=0.15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-movementX*Time.deltaTime,0,0);
        if(transform.position.x <=limitLet){
            transform.position=new Vector3(initialRight,transform.position.y,transform.position.z);
        }
    }
}
