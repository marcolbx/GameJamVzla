using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
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
                            //enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                            Rigidbody2D rb = enemiesToDamage[i].gameObject.GetComponent<Rigidbody2D>(); 
                            Transform tf = enemiesToDamage[i].gameObject.GetComponent<Transform>();
                            if(movementController.horizontal == 1){
                                rb.AddForce(new Vector3(tf.position.x* -knockbackEnemyForcex ,0,0));
                                rb.velocity = Vector2.up * knockbackEnemyForcey;
                            }
                            else if(movementController.horizontal == -1){
                                rb.AddForce(new Vector3(tf.position.x* knockbackEnemyForcex,0,0));
                                rb.velocity = Vector2.up * knockbackEnemyForcey;
                            }
                        }
                    }
                //}
                //else if(animator.GetBool("Book")==true){
                    //Shoot();
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
        
       /*  StatusController controller = GetComponent<StatusController>();
        if(controller.stamina>0){
            Instantiate(fireBolt, firePoint.position, firePoint.rotation);
            controller.stamina -= 0.1f;
        }
        */
    }
}
