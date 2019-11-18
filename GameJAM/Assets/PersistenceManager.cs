using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistenceManager : MonoBehaviour
{
    private static bool created = false;
    [SerializeField] private CameraX cameraPersistence;
    [SerializeField] private Player playerPersistence;
    [SerializeField] private GameObject cameraToPersist;
    [SerializeField] private GameObject playerToPersist;
    
    private bool _activate = false;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake: " + this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // called first
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(_activate)
        { 
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);

            //Player
            if(GameObject.FindGameObjectWithTag("Player"))
        playerToPersist = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("Player position: " + playerToPersist.transform.position);
        playerToPersist.transform.position = playerPersistence.SavedPlayerPosition();
        Debug.Log("Loaded Player position: " + playerPersistence.SavedPlayerPosition());

            //Camera
            if (GameObject.FindGameObjectWithTag("MainCamera"))
                cameraToPersist = GameObject.FindGameObjectWithTag("MainCamera");
            cameraToPersist.GetComponent<CameraX>().LoadCamera();
            Debug.Log("Camera position: " + cameraToPersist.transform.position);

            //cameraToPersist.transform.position = cameraPersistence.SavedCameraPosition();
            Debug.Log("Loaded Camera position: " + cameraPersistence.SavedCameraPosition());
        }
    }

    public void setActivate(bool activate)
    {
        this._activate = activate;
    }



}
