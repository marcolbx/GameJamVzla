using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilChest : MonoBehaviour
{
    public Animator animator;
    private bool pursuit = false;
    private Vector2 targetX; // solo en la X position
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        animator.SetTrigger("open");
    }

    public void PursuitMode()
    {
        pursuit = true;
    }
}
