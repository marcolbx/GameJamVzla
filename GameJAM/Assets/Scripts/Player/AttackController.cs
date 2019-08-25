﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        movementController = GetComponent<PlayerMovement>();
    }

    private void FixedUpdate() {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - firePoint.position;
        float rotZ = Mathf.Atan2(difference.y,difference.x) * Mathf.Rad2Deg;
        float rot=rotZ + offset;
        Debug.Log(firePoint.rotation.y);
        Debug.Log(firePoint.rotation.eulerAngles.y);
        if(movementController.horizontal>0 && rot<-1 && rot >-170f)
            firePoint.rotation= Quaternion.Euler(firePoint.rotation.x,firePoint.rotation.y,rot);
        else if(movementController.horizontal<0 && firePoint.rotation.y==-180 && rot>-20f)
            firePoint.rotation= Quaternion.Euler(firePoint.rotation.x,firePoint.rotation.y,rot);     
        else if(movementController.horizontal<0 && firePoint.rotation.y==0 && rot<-230f)
            firePoint.rotation= Quaternion.Euler(firePoint.rotation.x,firePoint.rotation.y,rot);
        else
        {
            firePoint.rotation= Quaternion.Euler(firePoint.rotation.x,firePoint.rotation.y,rot);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttackCounter<=0){
            if(Input.GetKey(KeyCode.Space)){
                //animator.SetBool("Attack",true);
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position,new Vector2(attackRangeX,attackRangeY),0,enemyLayer);
                Collider2D interactable = Physics2D.OverlapBox(attackPos.position,new Vector2(attackRangeX,attackRangeY),0,interactableLayer);
                //if(animator.GetBool("Sword")==true)
                //{
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
                //}
                //else if(animator.GetBool("Book")==true){
                    Shoot();
                //}
                if (interactable != null){
                    interactable.GetComponent<LiftSystemLever>().ActiveLever();
                }
                timeBtwAttackCounter=timeBtwAttack;  
            }
            
        }
        else{
            timeBtwAttackCounter -= Time.deltaTime;
            //animator.SetBool("Attack",false);
        } 
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position,new Vector3(attackRangeX,attackRangeY,1));
    }
    
    void Shoot(){
        
        /* if(rot>90f && movementController.horizontal>0)
            rot = 90f;
        if(rot<-90 && movementController.horizontal>0)
            rot = -90f;*/
        /* if(rot<90f && movementController.horizontal<0)
            rot = -90f;
         if(rot>-90 && movementController.horizontal<0)
            rot = +90f;
            */
        
        StatusController controller = GetComponent<StatusController>();
        if(controller.stamina>0){
            Instantiate(fireBolt, firePoint.position, firePoint.rotation);
            controller.stamina -= 0.1f;
        }
        
    }
}
