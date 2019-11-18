using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Nombre:  SavePointBench
 * Descripcion: Clase que al colisionar con el player, guarda la posicion del player y la camara. 
 * 
 */
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
