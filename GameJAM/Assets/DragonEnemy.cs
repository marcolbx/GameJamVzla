using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonEnemy : Enemy
{
    public GameObject projectile;
    [SerializeField] private float timeToShoot = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

        if(health >0 && timeToShoot <0)
        {
            InstantiateProjectile();
            timeToShoot =3f;                //Hay q cambiar esto si se cambia el 3 de arriba
        }

        timeToShoot -= Time.deltaTime;

    }

    void InstantiateProjectile()
    {
        Destroy(Instantiate(projectile,transform.position,Quaternion.identity),5f);
    }
}
