using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] private float timer = 0.85f;
    private bool oneTime = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0 && oneTime == false)
        {
            audioSource.Play();
            oneTime = true;
        }
    }
}
