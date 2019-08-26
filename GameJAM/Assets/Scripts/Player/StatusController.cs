﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{
    private int level=1;
    public float proportionExp=1f;
    private float experience=0;
    public float knockbackforcex;
    public GameObject staminaSlider;
    public GameObject experienceSlider;
    public float stamina=1;
    public float knockbackforcey;
    private Rigidbody2D rb;
    public int hearths;
    public int intialhearts=5;
    [SerializeField] private float invulnerableTimeCounter=0;
    public SpriteRenderer spriteRendHearth;
    public Sprite[] spriteHearths;
    [SerializeField] private float invulnerableTime;
    public bool invulnerability;
    public float checkRadius;
    public bool onHazard;
    public bool onHp;
    private float newExperience=0;
    [SerializeField]private float timer =0;
    [SerializeField] private float flashTime=0.2f;
    public LayerMask hazardLayer;
    public LayerMask hpLayer;
    private Collider2D col;
    private SpriteRenderer[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        hearths = intialhearts;
        rb = GetComponent<Rigidbody2D>();
        staminaSlider = GameObject.FindGameObjectWithTag("Stamina");
        experienceSlider = GameObject.FindGameObjectWithTag("Experience");
        sprites = gameObject.GetComponentsInChildren<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        experience = Mathf.Lerp(experience,newExperience,4*Time.deltaTime);
        experienceSlider.GetComponent<Image>().fillAmount =experience;
        staminaSlider.GetComponent<Slider>().value=stamina;
        onHazard = Physics2D.OverlapCircle(transform.position,checkRadius,hazardLayer);
        onHp = Physics2D.OverlapCircle(transform.position,checkRadius*2.5f,hpLayer);
        if(onHazard == true){
            if(hearths>0 && invulnerability == false){
                col = Physics2D.OverlapCircle(transform.position,checkRadius,hazardLayer);
                float dot = Vector2.Dot(transform.right,col.gameObject.transform.right);
                if(dot < -0.998){
                    rb.AddForce(new Vector3(knockbackforcex ,0,0));
                    rb.velocity = Vector2.up * knockbackforcey;
                    Debug.Log("izquierda");
                }
                else
                {
                    rb.AddForce(new Vector3(-knockbackforcex,0,0));
                    rb.velocity = Vector2.up * knockbackforcey;
                    Debug.Log("derecha");
                }
                hearths--;
                spriteRendHearth.sprite = spriteHearths[hearths];
                invulnerability =true;
            }    
        }
        if(onHp == true && hearths>0){
            col = Physics2D.OverlapCircle(transform.position,checkRadius*2.5f,hpLayer);
            Destroy(col.gameObject);
            if(hearths<intialhearts){
                hearths++;
                spriteRendHearth.sprite = spriteHearths[hearths];
            }
        }
        if (hearths<=0){
            Destroy(this.gameObject);
        }
        if(invulnerability == true){
            timer += Time.deltaTime;
            invulnerableTimeCounter +=Time.deltaTime;
            if(invulnerableTimeCounter>=invulnerableTime){
                invulnerability = false;
                invulnerableTimeCounter = 0;
            }
            if (timer >= flashTime){
                for(int i=0;i<sprites.Length;i++){
                    if(sprites[i].enabled== true){
                        sprites[i].enabled = false;
                        timer=0;
                    }
                    else{
                        sprites[i].enabled = true;
                        timer=0;
                    }
                }
            }
        }
        else{
            timer=0;
            for(int i=0;i<sprites.Length;i++){
                sprites[i].enabled = true;
            }
        }
    }

    public void TakeDamage()
    {
        if(hearths>0 && invulnerability == false)
        {
            rb.AddForce(new Vector3(transform.position.x- knockbackforcex,transform.position.y,transform.position.z));
            rb.velocity = Vector2.up * knockbackforcey;
            hearths--;
            spriteRendHearth.sprite = spriteHearths[hearths];
            invulnerability =true;
        }
    }

    public void ObtainExp(float exp){
        exp=exp/(level*proportionExp*100);
        if(newExperience + exp >=1){
            newExperience = (newExperience+exp)-1;
            proportionExp -= proportionExp/10;
        }
        else{
            newExperience +=exp;
        }
    }
}
