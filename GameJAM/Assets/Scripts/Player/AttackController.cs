﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public float staminaPerBullet;
    public float bulletTime;
    public float offset;
    public Transform firePoint;
    public GameObject fireBolt;
    public float knockbackEnemyForcex;
    public float knockbackEnemyForcey;
    [SerializeField]private float timeBtwAttack;
    [SerializeField] private float timeBtwAttackCounter;
    public Transform attackPos;
    public float attackRangeX;
    public float attackRangeY;
    public int damage;
    public LayerMask enemyLayer;
    public LayerMask interactableLayer;
    private GameObject Weapon;
    private Animator animator;
    private PlayerMovement movementController;
    private InventoryController inventoryController;
    private StatusController sc;
    public AudioSource yoyoSound;
    public AudioSource doorSound;
    public AudioSource slingShotSound;

    private bool ableToAtk = true;
    private float atkRate = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        movementController = GetComponent<PlayerMovement>();
        inventoryController = GetComponent<InventoryController>();
        sc = GetComponent<StatusController>();
    }

    private void FixedUpdate() {
        /* Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - firePoint.position;
        float rotZ = Mathf.Atan2(difference.y,difference.x) * Mathf.Rad2Deg;
        float rot=rotZ + offset;
        if(movementController.horizontal>0 && rot<-1 && rot >-170f)
            firePoint.rotation= Quaternion.Euler(firePoint.rotation.x,firePoint.rotation.y,rot);
        else if(movementController.horizontal<0 && firePoint.rotation.y==-180 && rot>-20f)
            firePoint.rotation= Quaternion.Euler(firePoint.rotation.x,firePoint.rotation.y,rot);     
        else if(movementController.horizontal<0 && firePoint.rotation.y==0 && rot<-230f)
            firePoint.rotation= Quaternion.Euler(firePoint.rotation.x,firePoint.rotation.y,rot);
        else
        {
            firePoint.rotation= Quaternion.Euler(firePoint.rotation.x,firePoint.rotation.y,rot);
        }*/
    }
    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttackCounter<=0){
            if(Input.GetKeyDown(KeyCode.Space)){
                animator.SetBool("Attack",true);
                Collider2D interactable = Physics2D.OverlapBox(attackPos.position,new Vector2(attackRangeX,attackRangeY),0,interactableLayer);
                if(ableToAtk)
                if(animator.GetBool("Yoyo")==true)
                {
                    MeleeAttack();
                }
                else if(animator.GetBool("SlingShot")==true){
                    Shoot();
                }
                if (interactable != null){
                    if(interactable.tag=="Door" && inventoryController.keys>0 ){
                        doorSound.Play();
                        interactable.GetComponent<DoorController>().OpenDoor();
                        inventoryController.keys--;
                    }
                    else if(interactable.tag=="Hp")
                    {
                        if(sc.hearths< sc.intialhearts && inventoryController.money>=100)
                        {
                            inventoryController.money-=100;
                            sc.hearths++;
                            sc.RefreshHealth();
                            sc.playerHeal.Play();
                            Destroy(interactable.gameObject);
                        }
                    }
                    else if(interactable.tag=="ItemSlingShot"){
                        if(inventoryController.slingshotWeapon==false &&  inventoryController.money>=500){
                            inventoryController.slingshotWeapon=true;
                            inventoryController.money-=500;
                            Destroy(interactable.gameObject);
                        }
                    }
                    else{
                        interactable.GetComponent<Interactable>().Action();
                    }
                }
                timeBtwAttackCounter=timeBtwAttack;  
            }
            
            
        }
        else{
            timeBtwAttackCounter -= Time.deltaTime;
            animator.SetBool("Attack",false);
        }
        atkRate += Time.deltaTime;
        if (atkRate > 0.4f)
            ableToAtk = true;
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position,new Vector3(attackRangeX,attackRangeY,1));
    }
    
    private void Shoot(){
        StatusController controller = GetComponent<StatusController>();
        if(controller.stamina>0){
            slingShotSound.Play();
            Destroy(Instantiate(fireBolt, firePoint.position, firePoint.rotation),bulletTime);
            controller.stamina -= staminaPerBullet;

        }
    }
    public void MeleeAttack(){
        ableToAtk = false;
        yoyoSound.Play();
        atkRate = 0;
        Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position,new Vector2(attackRangeX,attackRangeY),0,enemyLayer);
        if(enemiesToDamage.Length>0){
            for (int i=0; i < enemiesToDamage.Length; i++){
                enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                Rigidbody2D rb = enemiesToDamage[i].gameObject.GetComponent<Rigidbody2D>(); 
                if(movementController.horizontal == 1){
                    rb.AddForce(new Vector3(knockbackEnemyForcex ,0,0));
                    rb.velocity = Vector2.up * knockbackEnemyForcey;
                }
                else if(movementController.horizontal == -1){
                    rb.AddForce(new Vector3(-knockbackEnemyForcex,0,0));
                    rb.velocity = Vector2.up * knockbackEnemyForcey;
                }
            }
        }
        AttackRate();
    }

    public bool AttackRate()
    {
        if(atkRate > 0.4f)
        ableToAtk = true;
        return ableToAtk;
    }
}
