using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 90f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0 ,0 ,rotateSpeed * Time.deltaTime);
    }

    void StopRotation()
    {
        rotateSpeed = 0f;
    }
}