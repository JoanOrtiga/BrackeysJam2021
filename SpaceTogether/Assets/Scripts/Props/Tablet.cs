using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablet : MonoBehaviour
{
   
    public bool onHand = true;

    public Material MainMenuTexture,case1Texture, case2Texture, case3Texture, case4Texture;
    public GameObject screen;

    int clicks = 0;
    private void Start()
    {
        screen.GetComponent<MeshRenderer>().material = MainMenuTexture;
        onHand = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (onHand == true)
        {
           
            if (Input.GetMouseButtonDown(0))
            {
               
                if (clicks == 0)
                {
                    clicks++;
                    screen.GetComponent<MeshRenderer>().material = case1Texture;
           
                }
                else if (clicks ==1)
                {
                    clicks++;

                    screen.GetComponent<MeshRenderer>().material = case2Texture;
                }
                else if (clicks ==2 )
                {
                    clicks++;
                    screen.GetComponent<MeshRenderer>().material = case3Texture;
                }
                else if (clicks == 3)
                {
                    clicks++;
                    screen.GetComponent<MeshRenderer>().material = case4Texture;
                }
                else if (clicks == 4)
                {
                    screen.GetComponent<MeshRenderer>().material = case1Texture;
                    clicks = 1;
                }
                
               
            }
     
        }
    }
}
