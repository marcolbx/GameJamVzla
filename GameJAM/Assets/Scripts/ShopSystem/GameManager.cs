using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField] private float money;
    public Text moneyText;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = this;
        UpdateUI();
    }

    public void addMoney(float amount)
    {
        money += amount;
        UpdateUI();
    }

    public void reduceMoney(float amount)
    {
        money -= amount;
        UpdateUI();        
    }

    public bool checkMoney(float amount)
    {
        if (amount <= money){
            return true;
        }
        return false;
    }

    void UpdateUI()
    {
        moneyText.text = money.ToString() + "$";
    }
}
