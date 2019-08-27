using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CameraData
{
        public float[] position;
        public int level;
        public float[] maxPosition;
        public float[] minPosition;

        public CameraData(CameraX camera)
        {
            position = new float[3];
            position[0] = camera.transform.position.x;
            position[1] = camera.transform.position.y;
            position[2] = camera.transform.position.z;
            maxPosition = new float[2];
            minPosition = new float[2];
            maxPosition[0] = camera.maxPosition[0];
            maxPosition[1] = camera.maxPosition[1];
            minPosition[0] = camera.minPosition[0];
            minPosition[1] = camera.minPosition[1];
        }

}
