using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;

    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

    // Start is called before the first frame update
    void Start()
    {
         Camera cam = Camera.main;
            float height = 2f * cam.orthographicSize;
            float width = height * cam.aspect;
            xMin = transform.position.x - width/2;
            xMax = transform.position.x + width/2;
            yMin = transform.position.y - height/2;
            yMax = transform.position.y + height/2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
    
        if(transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x,target.position.y,transform.position.z);
           
            targetPosition.x = Mathf.Clamp(targetPosition.x,minPosition.x,maxPosition.x);           
            targetPosition.y = Mathf.Clamp(targetPosition.y,minPosition.y,maxPosition.y); 

            transform.position = Vector3.Lerp(transform.position,targetPosition,smoothing);
        }

    }


}
