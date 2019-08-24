using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float transitionTimer=0.2f;
    [SerializeField]
    private float walkingSpeed=1f;
    public float horizontal=1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transitionTimer <=0.2){
            transitionTimer +=Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            horizontal=1;
            transform.Translate(walkingSpeed* Time.deltaTime,0,0);
            transform.eulerAngles = new Vector3 (0,0,0);
        }
        else if(Input.GetKey(KeyCode.LeftArrow)){
            horizontal =-1;
            transform.Translate(walkingSpeed* Time.deltaTime*horizontal,0,0);
        }
        
    }
}
