using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
        public int level;
        public float[] position;
        public int money;
        public int amountKeys;
      //  public int health;

        public PlayerData(Player player)
        {
            level = player.level;
          //  health = player.health;
            position = new float[3];
            position[0] = player.transform.position.x;
            position[1] = player.transform.position.y +1f;
            position[2] = player.transform.position.z;
        }

}
