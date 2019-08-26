using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowEnemy : Enemy
{
    [SerializeField] private float timerToShoot = 0f;
    [SerializeField] private float minDistance = 8f;
    [SerializeField] private float transformDistance = 4f;
    public GameObject projectile;
    private bool atk = false;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        timerToShoot += Time.deltaTime;

        if(Vector2.Distance(this.transform.position,target.position) < minDistance)
        {
                atk = true;
        }
        else
        {
                atk = false;
        }

        if(health > 0)
        if(target.position.x < animator.transform.position.x)
        {
                animator.transform.eulerAngles = new Vector3(0,0,0);
        }
        
        else
        {

                animator.transform.eulerAngles = new Vector3(0,180,0);
        }
    }

    public void InstantiateProjectile()
    {
        if(timerToShoot >= 2.5f && health > 0 && atk == true)
        {
            GameObject bullet = Instantiate(projectile,transform.position,Quaternion.identity);
            timerToShoot = 0;
        }
    }
    
}
