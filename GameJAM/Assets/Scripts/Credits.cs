using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Credits : MonoBehaviour
{
    public  TextMeshProUGUI text;
    private string[] names = {"Tacos2x1","ofo978","guajava","Wendy_Sketches","RAM","marcolbx","",""};
    private float    timer = 3.5f;
    private int      counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        text.SetText(names[counter] );
    }

    // Update is called once per frame
    void Update()
    {
         if(timer < 0.0f) {
         counter++;
         text.SetText(names[counter] );
         timer = 3.5f;
         
        }
        timer -= Time.deltaTime;
        Debug.Log("Timer:" + timer);

        if(counter >5)
        Destroy(this);
    }
}
