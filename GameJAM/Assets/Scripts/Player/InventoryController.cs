﻿using System.Collections;
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
    private GameObject[] yoyo;
    private GameObject face;
    public Sprite[] leftArms;
    public int staminaLoss=2;
    public Sprite[] rightArms;
    public Sprite[] faces;
    public Sprite[] skills;
    public bool restore=false;
    private StatusController statusController;
    private GameObject[] wires;
    // Start is called before the first frame update
    void Start()
    {
        controlerImage.enabled = true;
        animator = GetComponent<Animator>();
        rightArm = GameObject.FindGameObjectWithTag("RightArm");
        leftArm = GameObject.FindGameObjectWithTag("LeftArm");
        face = GameObject.FindGameObjectWithTag("Face");
        yoyo = GameObject.FindGameObjectsWithTag("Yoyo");
        statusController = GetComponent<StatusController>();
        wires = GameObject.FindGameObjectsWithTag("SlingShot");
        EquipYoyo();

    }

    // Update is called once per frame
    void Update()
    {
        if(statusController.stamina <= 0 && restore == true){
            EquipYoyo();    
        }
        if(statusController.stamina > 0 && equipedGlass ==true){
            statusController.stamina -=Time.deltaTime/staminaLoss;
        }
        if(Input.GetKey(KeyCode.Alpha3)&& statusController.stamina+0.1f > 0){
            HideShow(wires,false);
            HideShow(yoyo,false);
            restore =true;
            controlerImage.sprite = skills[2];
            equipedGlass= true;
            rightArm.GetComponent<SpriteRenderer>().sprite = rightArms[0];
            leftArm.GetComponent<SpriteRenderer>().sprite = leftArms[1];
            face.GetComponent<SpriteRenderer>().sprite = faces[1];
            if(equipedGlass == false)
                statusController.stamina -=0.2f;
            animator.SetBool("Yoyo",false);
            animator.SetBool("SlingShot",false);
            animator.SetBool("Glass",true);
            
                
        }else if(Input.GetKey(KeyCode.Alpha1)){
            EquipYoyo();
        }
        else if(Input.GetKey(KeyCode.Alpha2)){
            HideShow(wires,true);
            restore = false;
            controlerImage.sprite = skills[1];
            rightArm.GetComponent<SpriteRenderer>().sprite = rightArms[1];
            leftArm.GetComponent<SpriteRenderer>().sprite = leftArms[2];
            face.GetComponent<SpriteRenderer>().sprite = faces[1];
            HideShow(yoyo,false);
            animator.SetBool("Yoyo",false);
            animator.SetBool("SlingShot",true);
            animator.SetBool("Glass",false);
            equipedGlass= false;
        }
    }

    public void HideShow(GameObject[] go,bool constraint){
        if(constraint ==true){
            for(int i=0;i<wires.Length;i++){
                go[i].GetComponent<SpriteRenderer>().enabled =true;
            }
        }
        else{
            for(int i=0;i<wires.Length;i++){
                go[i].GetComponent<SpriteRenderer>().enabled =false;
            }
        }
    }
    public void EquipYoyo(){
        HideShow(wires,false);
        HideShow(yoyo,true);
        restore = false;
        rightArm.GetComponent<SpriteRenderer>().sprite = rightArms[0];
        controlerImage.sprite = skills[0];
        leftArm.GetComponent<SpriteRenderer>().sprite = leftArms[0];
        face.GetComponent<SpriteRenderer>().sprite = faces[0];
        
        animator.SetBool("Yoyo",true);
        animator.SetBool("SlingShot",false);
        animator.SetBool("Glass",false);
        equipedGlass= false;
    }
    public bool GetPower(){
        return equipedGlass;
    }
}
