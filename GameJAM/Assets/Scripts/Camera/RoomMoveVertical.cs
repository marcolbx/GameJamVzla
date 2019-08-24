using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMoveVertical : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;
    public bool needText;
    public string placeName;
    public GameObject text;
    public bool upper = false;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        /* 
        if(other.CompareTag("Player") && !other.isTrigger && other.GetComponent<Rigidbody2D>().velocity.y >=-0.001 && upper == false && other.gameObject.GetComponent<PlayerMovement>().transitionTimer>=0.5f )
        {
            Debug.Log("TRIGGERED");
            Debug.Log("Velocity"+other.GetComponent<Rigidbody2D>().velocity);
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
        //    other.gameObject.GetComponent<PlayerMovement>().transitionTimer = 0;
            other.transform.position += playerChange;

        }
        else if (other.CompareTag("Player") && !other.isTrigger && other.GetComponent<Rigidbody2D>().velocity.y <-0.001 && upper == true && other.gameObject.GetComponent<PlayerMovement>().transitionTimer>=0.5f)
        {
            Debug.Log("TRIGGERED : upper = " + upper);
            Debug.Log("Velocity"+other.GetComponent<Rigidbody2D>().velocity);
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
          //  other.gameObject.GetComponent<PlayerMovement>().transitionTimer = 0;
            other.transform.position += playerChange;
        }
        */
    }
}
