using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public Transform pos1, pos2;
    [SerializeField] private float speed =2f;
    public Transform startPos;
    public LiftSystem system;

    Vector3 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == pos1.position && system.GetCurrentAction() >0)
        {
            nextPos = pos2.position;
            //system.ChangeCurrentAction(); //For Simulation purposes only
        }
        if(transform.position == pos2.position && system.GetCurrentAction() >0)
        {
            nextPos = pos1.position;
            //system.ChangeCurrentAction();//For Simulation purposes only
        }
        
        if(system.GetCurrentAction() >0)
        {
            transform.position = Vector3.MoveTowards(transform.position,nextPos,speed *Time.deltaTime);
            if(transform.position == nextPos)
            system.ChangeCurrentAction();
        }
        
    }
}
