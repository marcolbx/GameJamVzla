using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraX : MonoBehaviour
{
    public int level;
    public float[] maxPosition;
    public float[] minPosition;
    public CameraMovement cameraMovement;

    public void SaveCamera()
    {
        maxPosition = new float[2];
        minPosition = new float[2];
        maxPosition[0] = cameraMovement.maxPosition.x;
        maxPosition[1] = cameraMovement.maxPosition.y;
        minPosition[0] = cameraMovement.minPosition.x;
        minPosition[1] = cameraMovement.minPosition.y;
        SaveSystem.SaveCamera(this);
    }

    public void LoadCamera()
    {
        CameraData data = SaveSystem.LoadCamera();
        level = data.level;


        Vector3 pos;    
        pos.x = data.position[0];
        pos.y = data.position[1];
        pos.z = data.position[2];
        Debug.Log("Loaded: x:" + pos.x + "Y" + pos.y + "Z" + pos.z);
        transform.position = pos;

        maxPosition = new float[2];
        minPosition = new float[2];

        maxPosition = data.maxPosition; //Obtengo el arreglo de posiciones
        minPosition = data.minPosition;
        Debug.Log("Loaded: Max" + maxPosition);
        Debug.Log("Loaded: Min" + minPosition);


        cameraMovement.maxPosition.x = maxPosition[0];
        cameraMovement.maxPosition.y = maxPosition[1];
        cameraMovement.minPosition.x = minPosition[0];
        cameraMovement.minPosition.y = minPosition[1];
    }

    public Vector3 SavedCameraPosition()
    {
        CameraData data = SaveSystem.LoadCamera();
        Vector3 pos;
        pos.x = data.position[0];
        pos.y = data.position[1];
        pos.z = data.position[2];
        return  pos;
    }
}
