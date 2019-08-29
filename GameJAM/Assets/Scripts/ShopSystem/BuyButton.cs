using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public int skillID;
    public Text buttonText;

    public void buySkill()
    {
        if (skillID == 0)
        {
            Debug.Log("NO SKILL ID SET¡");
            return;
        }

        for (int i=0; i<SkillShop.skillShop.skillList.Count; i++)
        {
            if (SkillShop.skillShop.skillList[i].skillID == skillID && 
                !SkillShop.skillShop.skillList[i].bought && 
                GameManager.gameManager.checkMoney(SkillShop.skillShop.skillList[i].skillPrice))
            {
                SkillShop.skillShop.skillList[i].bought = true;
                GameManager.gameManager.reduceMoney( SkillShop.skillShop.skillList[i].skillPrice);
                updateBuyButton();
            }
            else if(SkillShop.skillShop.skillList[i].skillID == skillID && 
                    !SkillShop.skillShop.skillList[i].bought && 
                    !GameManager.gameManager.checkMoney(SkillShop.skillShop.skillList[i].skillPrice))
            {
                Debug.Log("NOT ENOUGHT MONEY!!");
            }
            else if(SkillShop.skillShop.skillList[i].skillID == skillID && SkillShop.skillShop.skillList[i].bought)
            {
                Debug.Log("YOU ALREADY BOUGHT!!");
                updateBuyButton();
            }
        }

        SkillShop.skillShop.updateSprite(skillID);
    }

    void updateBuyButton()
    {
        buttonText.text = "Using";
    }
}
