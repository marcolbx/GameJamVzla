using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;
    public CameraMovement cameraMov;
    [SerializeField] private bool isBossLVL = false;   //SOLO SI ES DEL BOSS ROOM #Hardcoded

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
        
        if(other.CompareTag("Player") && !other.isTrigger && other.gameObject.GetComponent<PlayerMovement>().transitionTimer>=0.2f)
        {
            if(isBossLVL == false)
            {
            Debug.Log("TRIGGERED");
            Debug.Log("Velocity"+other.GetComponent<Rigidbody2D>().velocity);
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
      //  //    other.gameObject.GetComponent<PlayerMovement>().transitionTimer = 0;
            other.transform.position += playerChange;
            cameraMov.justLoaded = false;
            if(needText)
            {
                StartCoroutine(placeNameCo());
            }
            }

            else
            {
                Debug.Log("TRIGGERED");
            Debug.Log("Velocity"+other.GetComponent<Rigidbody2D>().velocity);
            cam.minPosition = new Vector2(0,0);
            cam.maxPosition = new Vector2(0,0);
      //  //    other.gameObject.GetComponent<PlayerMovement>().transitionTimer = 0;
            other.transform.position += playerChange;
            cameraMov.justLoaded = false;
            if(needText)
            {
                StartCoroutine(placeNameCo());
            }
            }

        }
        
    }

    private IEnumerator placeNameCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }
}
