using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilChestAtkBehaviour : StateMachineBehaviour
{
    Transform target;
    private Vector2 targetX; // solo en la X position
    private float health;
    [SerializeField] private float speed =1f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       target = PlayerManager.instance.player.transform;
        targetX = new Vector2(target.position.x,animator.transform.position.y);
        animator.SetFloat("Hp",health);
        if(target.position.x < animator.transform.position.x)
        {
                animator.transform.eulerAngles = new Vector3(0,0,0);
        }
        
        else
        {

                animator.transform.eulerAngles = new Vector3(0,180,0);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position,targetX,speed * Time.deltaTime);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
