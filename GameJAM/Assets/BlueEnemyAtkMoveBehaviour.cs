using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemyAtkMoveBehaviour : StateMachineBehaviour
{
    private Transform target;
    private Vector2 targetX; // solo en la X position
    [SerializeField] private float minDistance = 4f;
    private AudioSource audioSource;
    private bool soundPlayed = false;
    [SerializeField] private float speed = 2.6f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       target = PlayerManager.instance.player.transform;
        targetX = new Vector2(target.position.x,animator.transform.position.y);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = PlayerManager.instance.player.transform;
        targetX = new Vector2(target.position.x,animator.transform.position.y);
        
        if(Vector2.Distance(animator.transform.position,target.position) < minDistance +2f)
        {

            animator.transform.position = Vector2.MoveTowards(animator.transform.position,targetX,speed * Time.deltaTime);
            
            if(target.position.x < animator.transform.position.x && Vector2.Distance(animator.transform.position,target.position) > 1f)
            {
                animator.transform.eulerAngles = new Vector3(0,0,0);
            }
        
            else if(target.position.x >= animator.transform.position.x && Vector2.Distance(animator.transform.position,target.position) > 1f)
            {

                animator.transform.eulerAngles = new Vector3(0,180,0);
            }

        }
        else
        {
        animator.ResetTrigger("Pursuit");
        animator.SetTrigger("Idle");
        }
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
