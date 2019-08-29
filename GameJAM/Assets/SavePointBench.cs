using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointBench : MonoBehaviour
{

public Player player;
public CameraX cameraX;
[SerializeField] private int level =0;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger)
        {   
            player.level = this.level;
            player.SavePlayer();
            cameraX.SaveCamera();
            Debug.Log("GameSaved");
        }
        
    }

    
}
