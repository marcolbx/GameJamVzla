using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public Sprite Yoyo;
    public SpriteRenderer controlerImage;
    public bool equipedMask=false;
    private GameObject maskObject;
    private Animator animator;
    private GameObject rightArm;
    private GameObject weapon;
    public Sprite[] LeftArms;
    public Sprite[] RightArms;
    public StatusController statusController;
    // Start is called before the first frame update
    void Start()
    {
        controlerImage.enabled = false;
        maskObject = GameObject.FindGameObjectWithTag("Mask");
        maskObject.GetComponent<SpriteRenderer>().enabled=false;
        animator = GetComponent<Animator>();
        rightArm = GameObject.FindGameObjectWithTag("RightArm");
        weapon =  GameObject.FindGameObjectWithTag("Weapon");
        animator.SetBool("Sword",true);
        statusController = GetComponent<StatusController>();

    }

    // Update is called once per frame
    void Update()
    {
        if(statusController.stamina <= 0){
            controlerImage.sprite = null;
            controlerImage.enabled = false;
            equipedMask=false;
            maskObject.GetComponent<SpriteRenderer>().enabled=false;
        }
        if(statusController.stamina > 0 && equipedMask ==true){
            statusController.stamina -=Time.deltaTime/10;
        }
        if(Input.GetKeyDown(KeyCode.F)&& statusController.stamina > 0){
            if(controlerImage.enabled == false){
                controlerImage.enabled = true;
                //controlerImage.sprite = mask;
                equipedMask= true;
                statusController.stamina -=0.1f;
                maskObject.GetComponent<SpriteRenderer>().enabled=true;
            }
            else{
                if(equipedMask==true){
                    controlerImage.sprite = null;
                    controlerImage.enabled = false;
                    equipedMask=false;
                    maskObject.GetComponent<SpriteRenderer>().enabled=false;
                }
                else{
                    //controlerImage.sprite = mask;
                    equipedMask= true;
                    maskObject.GetComponent<SpriteRenderer>().enabled=true;
                }
            }
        }else if(Input.GetKeyDown(KeyCode.Alpha1)){
            rightArm.GetComponent<SpriteRenderer>().sprite = LeftArms[1];
            weapon.GetComponent<SpriteRenderer>().enabled=true;
            animator.SetBool("Sword",true);
            animator.SetBool("Book",false);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2)){
            rightArm.GetComponent<SpriteRenderer>().sprite = LeftArms[0];
            weapon.GetComponent<SpriteRenderer>().enabled=false;
            animator.SetBool("Sword",false);
            animator.SetBool("Book",true);
        }
    }
    public bool GetPower(){
        return equipedMask;
    }
}
