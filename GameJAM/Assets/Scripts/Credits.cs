using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Credits : MonoBehaviour
{
    public  TextMeshProUGUI text;
    private string[] names = 
    {"Artist                                                 (Main Character Design and others): Juan Andres Perez"
    ,"Artist                                              (Tilesets and others):                       Omar Qataberi "
    ,"Artist                                           (Enemies & Backgrounds): Wendy_Sketches"
    ,"Musician                                             (First Level Theme and sound effects): guajava"
    ,"Musician                                           (Main Menu and Boss Theme and SFX): Ernesto Reyes"
    ,"Programmer                             (Character movement & others):   Ramiro Vargas"
    ,"Programmer                                  (Enemy Artificial Intelligence & others): Marco Lozano Bethke"
    ,"We want to thank BlackThornProd & Brackeys for their constant teaching..."
    ," Thanks For Playing Our Game! "
    ," Thanks For Playing Our Game! "
    ," Thanks For Playing Our Game! "};
    private float    timer = 5f;
    private int      counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        text.SetText(names[counter] );
    }

    // Update is called once per frame
    void Update()
    {
         if(timer < 0.0f) {
         counter++;
         text.SetText(names[counter] );
         timer = 5f;
         
        }
        timer -= Time.deltaTime;
        Debug.Log("Timer:" + timer);

        if(counter >9)
        {
            SceneManager.LoadScene("MainMenu");
        }
        
    }
}
