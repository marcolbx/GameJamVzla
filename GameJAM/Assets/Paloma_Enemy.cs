using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paloma_Enemy : Enemy
{

    [SerializeField] private float minWaypointDistance = 1f;
    public Transform waypointRight;
    public Transform waypointLeft;
    private Transform waypointToGo;
    // Start is called before the first frame update
    void Start()
    {
         float distance1 = Vector2.Distance(transform.position,waypointLeft.position);
                float distance2 = Vector2.Distance(transform.position,waypointRight.position);
        
                if(distance1> distance2)
                {
                    waypointToGo = waypointLeft;
                    transform.eulerAngles = new Vector3(0,0,0);
                }
                
                else
                {
                waypointToGo = waypointRight;
                transform.eulerAngles = new Vector3(0,180,0);
                }
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if(health >0)
        {

        
        transform.position = Vector2.MoveTowards(transform.position,waypointToGo.position,speed * Time.deltaTime);
                if(Vector2.Distance(this.transform.position,waypointToGo.position) < minWaypointDistance)
                {

                    if(waypointLeft == waypointToGo)
                    {
                        waypointToGo = waypointRight;
                        transform.eulerAngles = new Vector3(0,180,0);
                    }
                    
                    else
                    {
                        transform.eulerAngles = new Vector3(0,0,0);
                        waypointToGo = waypointLeft;
                    }
                }
        }
    }
}
