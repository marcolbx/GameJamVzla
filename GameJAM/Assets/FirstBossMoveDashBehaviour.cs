using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossMoveDashBehaviour : StateMachineBehaviour
{
    private Transform waypointLeft;
    private Transform waypointRight;
    private Transform waypointToGo;
    public float speed =5f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        waypointLeft = GameObject.FindGameObjectWithTag("Waypoint").GetComponent<Transform>();
        waypointRight = GameObject.FindGameObjectWithTag("Waypoint2").GetComponent<Transform>();

        float distance1 = Vector2.Distance(animator.transform.position,waypointLeft.position);
        float distance2 = Vector2.Distance(animator.transform.position,waypointRight.position);
        int random = Random.Range(0,2);
        if(random == 0)
        waypointToGo = waypointLeft;
        else
        {
            waypointToGo = waypointRight;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
         animator.transform.position = Vector2.MoveTowards(animator.transform.position,waypointToGo.position, speed * Time.deltaTime);
         if(Vector2.Distance(animator.transform.position,waypointToGo.position) < 0.5f)
        animator.SetTrigger("Idle");
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
