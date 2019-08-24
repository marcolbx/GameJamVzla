using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    public bool attachWidth = true;     // permite fijar el ancho de la camara al tamaño de la ventana
    [Range(-1,1)]
    public int adaptPosition=-1;
    private float cameraWidth; //variable para almacenar el tamaño inicial de la camara
    private float cameraHeight; //
    Vector3 cameraPos;
    // Start is called before the first frame update
    void Start()
    {
        cameraPos = Camera.main.transform.position;
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if (attachWidth){
            Camera.main.orthographicSize = cameraWidth / Camera.main.aspect;

            Camera.main.transform.position = new Vector3(cameraPos.x,adaptPosition*(cameraHeight-Camera.main.orthographicSize-cameraPos.y),cameraPos.z);
        }
        else{
            Camera.main.transform.position = new Vector3(adaptPosition*(cameraWidth-Camera.main.orthographicSize*Camera.main.aspect),cameraPos.y,cameraPos.z);
        }
    }
}
