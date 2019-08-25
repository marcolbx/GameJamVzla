using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftSystem : Interactable
{
    public Animator[] leverAnimators;
    public Collider2D[] leverColliders;
    [SerializeField] private bool startUp = true; //Empezo arriba
    private bool goDown = false;
    private bool goUp = false;
    private int currentAction = 0; // 0 nada, 1 goDown, 2 goUp
    public AudioSource leverSound;
    public AudioSource startSound;
    public AudioSource movementSound;
    public AudioSource endSound;
    private bool playOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log("currentAction" + currentAction);
       // ChangeLever();
        Debug.Log("goDown" + goDown);
        Debug.Log("goUp" + goUp);
        if(currentAction > 0 && playOnce == false)
        {
            movementSound.Play();
            playOnce = true;
        }
        
        

       // Debug.Log("currentAction" + currentAction);
    }

    public override void Action()
    {
        if(currentAction == 0 && goDown ==false && goUp == false && startUp==true)
        {
            leverSound.Play();
            startSound.Play();
            
            Debug.Log("ChangeLever");
            goDown=true;
            currentAction = 1; //goDown
            foreach (Animator animator in leverAnimators)
            {
                animator.SetBool("goDown",true);
            }
        }

        if(currentAction == 0 && goDown == false && goUp == false && startUp ==false)
        {
            leverSound.Play();
            startSound.Play();
           // movementSound.Play();
            Debug.Log("ChangeLever");
            goUp = true;
            currentAction = 2; // goUp
            foreach (Animator animator in leverAnimators)
            {
                animator.SetBool("goUp",true);
            }
        }
    }

    public void ChangeCurrentAction()
    {
         Debug.Log("ChangeCurrentAction");
        if(currentAction == 1)
        startUp = false;
        if(currentAction == 2)
        startUp = true;
        currentAction = 0;
        goDown=false;
        goUp = false;
        playOnce = false;
        movementSound.Stop();
        endSound.Play();
        foreach (Animator animator in leverAnimators)
            {
                animator.SetBool("goDown",false);
                animator.SetBool("goUp",false);
            }
    }

    public int GetCurrentAction()
    {
        Debug.Log("currentAction :" + currentAction);
        return currentAction;
    }


}
