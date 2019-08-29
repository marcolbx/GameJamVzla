using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillShop : MonoBehaviour
{
    public static SkillShop skillShop;
    public List<Skills> skillList = new List<Skills>();
    private List<GameObject> itemHolderList = new List<GameObject>();
    private List <GameObject> buyButtonList = new List<GameObject>();
    public GameObject itemHolderPrefab;
    public Transform grid;
    // Start is called before the first frame update
    void Start()
    {
        skillShop = this;
        fillList();
    }

    void fillList()
    {
        for(int i=0; i < skillList.Count; i++)
        {
            GameObject holder = Instantiate(itemHolderPrefab, grid);
            Itemholder holderScript = holder.GetComponent<Itemholder>();

            holderScript.itemName.text = skillList[i].skillName;
            holderScript.itemPrice.text = skillList[i].skillPrice.ToString();
            holderScript.itemID = skillList[i].skillID;
            //BUY BUTTON
            holderScript.buybutton.GetComponent<BuyButton>().skillID = skillList[i].skillID;
            itemHolderList.Add(holder);
            buyButtonList.Add(holderScript.buybutton);
            
            if (skillList[i].bought){
                holderScript.itemImage.sprite = skillList[i].boughtSprite;
            }else{
                holderScript.itemImage.sprite = skillList[i].unboughtSprite;
            }
            
        }
    }

    public void updateSprite(int skillID)
    {
        for(int i=0; i< itemHolderList.Count; i++)
        {
            Itemholder holderScript = itemHolderList[i].GetComponent<Itemholder>();
               
            if (holderScript.itemID == skillID)
            {
               for (int j=0; j<skillList.Count;j++)
               {
                   if(skillList[j].skillID == skillID)
                   {
                        if (skillList[j].bought){
                            holderScript.itemImage.sprite = skillList[j].boughtSprite;
                            holderScript.itemPrice.text = "Sold Out!";
                        }else{
                            holderScript.itemImage.sprite = skillList[j].unboughtSprite;
                        }
                    }
               }     
            }
        }
    }
}
