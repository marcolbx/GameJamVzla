using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CameraData : MonoBehaviour
{
        public float[] position;
      //  public int health;

        public CameraData(Camera camera)
        {
          //  health = player.health;
            position = new float[3];
            position[0] = camera.transform.position.x;
            position[1] = camera.transform.position.y;
            position[2] = camera.transform.position.z;
        }

}
