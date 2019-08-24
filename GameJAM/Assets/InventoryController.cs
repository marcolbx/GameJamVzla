using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public Sprite glass;
    private Image controlerImage;
    public bool equipedMask=false;
    // Start is called before the first frame update
    void Start()
    {
        controlerImage = GetComponent<Image>();
        controlerImage.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)){
            if(controlerImage.enabled == false){
                controlerImage.enabled = true;
                controlerImage.sprite = glass;
                equipedMask= true;
            }
            else{
                if(equipedMask==true){
                    controlerImage.sprite = null;
                    controlerImage.enabled = false;
                }
                else{
                    controlerImage.sprite = glass;
                }
            }
        }
    }
}
