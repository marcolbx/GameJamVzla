using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator transitionAnim;
    public string sceneName;
    private bool triggered = false;
    private bool triggeredOnce = false;
    [SerializeField] private bool isBossLvl = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(triggered)
        {
            if(triggeredOnce == false)
            {
                    StartCoroutine(LoadScene());
                    triggeredOnce = true;
            }
        
        }
    }

    IEnumerator LoadScene()
    {
        if(transitionAnim!=null)
        {
            if(isBossLvl == true)
            yield return new WaitForSeconds(4f);
            transitionAnim.SetTrigger("end");
        }
            
            if(isBossLvl == false)
        yield return new WaitForSeconds(0.9f);
        else
        {
            yield return new WaitForSeconds(5f);
        }
        SceneManager.LoadScene(sceneName);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !other.isTrigger)
        triggered = true;
    }

    public void LoadNextScene()
    {
        triggered = true;
    }
}
