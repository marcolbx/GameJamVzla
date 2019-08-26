using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer renderer;
    [SerializeField] bool isEvil = false;
    [SerializeField] private float speed =4f;
    private int random;
    [SerializeField] private float timer =3f;
    private int result;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        renderer.sprite = sprites[random];
        if(timer>0)
        Randomize();

        if(timer<= 0 && isEvil)
        renderer.sprite = sprites[5];

        else if (timer <= 0 && isEvil == false)
        {
            renderer.sprite = sprites[random];
            result = random;
        }
        

        timer -= Time.deltaTime;
    }

    void Randomize() 
    {
        random = Random.Range(0,6);

    }
}
