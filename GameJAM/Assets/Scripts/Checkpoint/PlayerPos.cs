using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
    private GameMaster gameMaster;
    // Start is called before the first frame update
    void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gameMaster.lastCheckpointPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
