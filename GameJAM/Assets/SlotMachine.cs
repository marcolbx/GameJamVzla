using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachine : Interactable
{
    public SpriteRenderer[] slotReelRenderers;
    public Sprite[] slotReelSprites;  //0 Enemy, 1 Hazard, 2 Money
    [SerializeField] bool isEvil = false;
    [SerializeField] private float speed =4f;
    private int random;
    [SerializeField] private float timer =3f;
    private int result;
    public GameObject[] enemies;
    public GameObject[] hazards;
    public GameObject chest;
    [SerializeField] private bool activated =false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(activated == true)
        {
            if(timer>0)
            Randomize();

            if(timer<= 0 && isEvil)
            {
            slotReelRenderers[0].sprite = slotReelSprites[0]; //Enemies
            slotReelRenderers[1].sprite = slotReelSprites[0]; //Enemies
            slotReelRenderers[2].sprite = slotReelSprites[0]; //Enemies
            }
        

            else if (timer <= 0 && isEvil == false)
            {
                foreach (SpriteRenderer renderer in slotReelRenderers)
                {
                    renderer.sprite = slotReelSprites[random];
                    result = random;
                }
            
            }
        

         timer -= Time.deltaTime;
        }
    }

    public override void Action()
    {
        Randomize();
    }

    void Randomize() 
    {
        random = Random.Range(0,3);

                int i = Random.Range(0,3);
                int j = Random.Range(0,3);
                int k = Random.Range(0,3);
                slotReelRenderers[0].sprite = slotReelSprites[i];
                slotReelRenderers[1].sprite = slotReelSprites[j];
                slotReelRenderers[2].sprite = slotReelSprites[k];
            
    }
}
