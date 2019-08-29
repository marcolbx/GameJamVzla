using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCinematicScript : MonoBehaviour
{
    public GameObject[] confusedEyes;
    public Sprite faceSprite;
    public SpriteRenderer headRenderer;

    int counter = 0;
    Animator animator;
    public AudioSource audioSource;
    public SceneTransition transition;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.Play();
            counter += 1;
            if(counter == 1)
            {
                foreach (GameObject item in confusedEyes)
                {
                item.SetActive(false);
                }
            }
            if(counter == 2)
            {
                headRenderer.sprite = faceSprite;
            }

            if(counter >= 3)
            {
                animator.SetTrigger("Stand");
            }

            if(counter>= 6)
            {
                transition.LoadNextScene();
            }
            
        }
    }


}
