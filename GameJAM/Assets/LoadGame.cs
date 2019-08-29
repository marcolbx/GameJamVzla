using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGameScene()
    {
        Debug.Log("Player.level= " +  player.level);
        if(player.level == 3)
        SceneManager.LoadScene("BossScene");

        if(player.level == 0)
        SceneManager.LoadScene("Player Scene 2");
    }
}
