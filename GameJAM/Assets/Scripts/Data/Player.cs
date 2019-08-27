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
      //  money = this.gameObject.GetComponent<>().money;
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

        Vector3 pos;
        pos.x = data.position[0];
        pos.y = data.position[1];
        pos.z = data.position[2];
        transform.position = pos;
    }

    public Vector3 SavedPlayerPosition()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        Vector3 pos;
        pos.x = data.position[0];
        pos.y = data.position[1];
        pos.z = data.position[2];
        return  pos;
    }
}
