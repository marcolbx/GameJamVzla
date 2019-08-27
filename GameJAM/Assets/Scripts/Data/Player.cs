using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int level;
    public int money;
    public int amountKeys;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        level = data.level;
        money = data.money;
        amountKeys = data.amountKeys;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[0];
        position.z = data.position[0];
        transform.position = position;
    }
}
