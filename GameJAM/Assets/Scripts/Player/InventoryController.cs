using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public SpriteRenderer controlerImage;
    public bool equipedGlass=false;
    private Animator animator;
    private GameObject rightArm;
    private GameObject leftArm;
    private GameObject yoyoObject;
    private GameObject yoyoWire;
    private GameObject face;
    public Sprite[] leftArms;
    public Sprite[] rightArms;
    public Sprite[] faces;
    public Sprite[] skills;
    public bool restore=false;
    private StatusController statusController;
    // Start is called before the first frame update
    void Start()
    {
        controlerImage.enabled = true;
        animator = GetComponent<Animator>();
        rightArm = GameObject.FindGameObjectWithTag("RightArm");
        leftArm = GameObject.FindGameObjectWithTag("LeftArm");
        face = GameObject.FindGameObjectWithTag("Face");
        yoyoObject = GameObject.FindGameObjectWithTag("Yoyo");
        yoyoWire =  GameObject.FindGameObjectWithTag("YoyoWire");
        statusController = GetComponent<StatusController>();
        EquipYoyo();

    }

    // Update is called once per frame
    void Update()
    {
        if(statusController.stamina <= 0 && restore == true){
            EquipYoyo();    
        }
        if(statusController.stamina > 0 && equipedGlass ==true){
            statusController.stamina -=Time.deltaTime/10;
        }
        if(Input.GetKey(KeyCode.Alpha3)&& statusController.stamina+0.1f > 0){
            restore =true;
            controlerImage.sprite = skills[2];
            equipedGlass= true;
            rightArm.GetComponent<SpriteRenderer>().sprite = rightArms[0];
            leftArm.GetComponent<SpriteRenderer>().sprite = leftArms[1];
            face.GetComponent<SpriteRenderer>().sprite = faces[1];
            if(equipedGlass == false)
                statusController.stamina -=0.1f;
            animator.SetBool("Yoyo",false);
            animator.SetBool("SlingShot",false);
            animator.SetBool("Glass",true);
            yoyoObject.GetComponent<SpriteRenderer>().enabled=false;
            yoyoWire.GetComponent<SpriteRenderer>().enabled=false;
                
        }else if(Input.GetKey(KeyCode.Alpha1)){
            EquipYoyo();
        }
        else if(Input.GetKey(KeyCode.Alpha2)){
            restore = false;
            controlerImage.sprite = skills[1];
            rightArm.GetComponent<SpriteRenderer>().sprite = rightArms[1];
            leftArm.GetComponent<SpriteRenderer>().sprite = leftArms[2];
            face.GetComponent<SpriteRenderer>().sprite = faces[1];
            yoyoObject.GetComponent<SpriteRenderer>().enabled=false;
            yoyoWire.GetComponent<SpriteRenderer>().enabled=false;
            animator.SetBool("Yoyo",false);
            animator.SetBool("SlingShot",true);
            animator.SetBool("Glass",false);
            equipedGlass= false;
        }
    }

    public void EquipYoyo(){
        restore = false;
        rightArm.GetComponent<SpriteRenderer>().sprite = rightArms[0];
        controlerImage.sprite = skills[0];
        leftArm.GetComponent<SpriteRenderer>().sprite = leftArms[0];
        face.GetComponent<SpriteRenderer>().sprite = faces[0];
        yoyoObject.GetComponent<SpriteRenderer>().enabled=true;
        yoyoWire.GetComponent<SpriteRenderer>().enabled=true;
        animator.SetBool("Yoyo",true);
        animator.SetBool("SlingShot",false);
        animator.SetBool("Glass",false);
        equipedGlass= false;
    }
    public bool GetPower(){
        return equipedGlass;
    }
}
