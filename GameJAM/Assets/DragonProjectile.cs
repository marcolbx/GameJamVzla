using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonProjectile : MonoBehaviour
{
    public float speed =4f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this,8f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed, Camera.main.transform);
    }
}
