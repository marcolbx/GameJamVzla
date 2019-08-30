using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonProjectile : MonoBehaviour
{
    public float speed =4f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed, Camera.main.transform);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(this);
    }

}
