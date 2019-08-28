using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBossIdle : StateMachineBehaviour
{
    private int rand;
    private Transform playerPos;
    private float timer = 5f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        //Random
        timer = 5f;
       rand = Random.Range(1,4);

        if(timer <= 0f)
        {
            rand = Random.Range(1,10);
            Debug.Log("Random" + rand);
            if(rand == 1)
       animator.SetInteger("Attack",1);
       else if(rand==2)
       {
           animator.SetInteger("Attack",2);
       }
       else
       {
           animator.SetInteger("Attack",3);
       }
        }

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer -= Time.deltaTime;


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
