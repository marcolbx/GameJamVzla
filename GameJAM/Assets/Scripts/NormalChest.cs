using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalChest : MonoBehaviour
{
    public Animator animator;
    public GameObject coin;
    public GameObject diamond;
    public GameObject topaz;
    [SerializeField] private int quantity = 7;
    public bool action = false; //Sim solamente;
    private float timer = 0.5f;
    private bool burst =false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(action)
        {
            Action();
            action = false;
        }

        if(burst == true)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            InstantiateMoney();
            timer = 0.5f;
            burst = false;
        }

    }

    public void Action()
    {
        animator.SetTrigger("open");
        burst = true;
       // InstantiateMoney();
    }

    private void InstantiateMoney()
    {
        int randomCoins = Random.Range(1,8);
        int randomDiamonds = Random.Range(0,2);
        int randomTopaz = Random.Range(0,4);

        for (int i = 0; i <=randomCoins; i++)
        {
            Instantiate(coin,transform.position,Quaternion.identity);
        }
        for (int i = 0; i <=randomDiamonds; i++)
        {
            Instantiate(diamond,transform.position,Quaternion.identity);
        }
        for (int i = 0; i <=randomTopaz; i++)
        {
            Instantiate(topaz,transform.position,Quaternion.identity);
        }
    }
}
