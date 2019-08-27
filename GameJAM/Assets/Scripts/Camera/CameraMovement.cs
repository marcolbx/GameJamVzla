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

    public bool justLoaded = false;
    public Vector3 savedPosition;
    public CameraX cameraX;
    public Player player;
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
    void Update()
    {
    
        if(transform.position != target.position && justLoaded==false)
        {
            Vector3 targetPosition = new Vector3(target.position.x,target.position.y,transform.position.z);
         //  Debug.Log("X" + targetPosition.x + "Y" + targetPosition.y + "Z" + targetPosition.z );
            targetPosition.x = Mathf.Clamp(targetPosition.x,minPosition.x,maxPosition.x);           
            targetPosition.y = Mathf.Clamp(targetPosition.y,minPosition.y,maxPosition.y); 

            transform.position = Vector3.Lerp(transform.position,targetPosition,smoothing);
        }
        else if(justLoaded == true)
        {
           // transform.position = transform.position;
            savedPosition = cameraX.SavedCameraPosition();
            target = PlayerManager.instance.player.transform;
            transform.position = savedPosition;
        }

    }

    public void SetLoadedPositions(Vector2 max, Vector2 min)
    {
        this.maxPosition = max;
        this.minPosition = min;
    }


}
