using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;
    public Transform player;
    private bool triggered = false;
    public GameObject canvasObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Vector2.Distance(player.transform.position,this.transform.position) < 5f)
        {
            canvasObject.GetComponent<Canvas>().enabled = true;
            if(triggered == false)
            TriggerDialogue();
            triggered = true;
        }
        else
        {
            triggered = false;
            canvasObject.GetComponent<Canvas>().enabled = false;
        }
        
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
