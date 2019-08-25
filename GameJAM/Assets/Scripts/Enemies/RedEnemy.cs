using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : Enemy
{
    private Vector2 targetX; // solo en la X position
    [SerializeField] private float minDistance = 4f;
    [SerializeField] private float normalSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    override protected void Update()
    {
        base.Update();
    }
}
