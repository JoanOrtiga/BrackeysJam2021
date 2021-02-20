using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trasmitator : MonoBehaviour
{

    public Material EmisiveOn;
    public Material EmisiveOff;
    public Material MessageOff;

    public MeshRenderer render;
    // Start is called before the first frame update
    private bool act4;
    private bool enter; 

    float time = 0;
    float timeEmesive;

    // Update is called once per frame
    void Update()
    {
        changeMat();
        timeEmesive += Time.deltaTime;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && act4 == true)
        {
            enter = true;
            //ADD OPTION
        }
    }

    private void changeMat()
    {
        if (enter == true && act4 == true)
        {

            time += Time.deltaTime;
        }

        if (time > 20)
        {
            render.material = MessageOff;
        }
        else if (timeEmesive < 1)
        {


            render.material = EmisiveOff;
        }
        else if (timeEmesive < 2)
        {

            render.material = EmisiveOn;
        }
        else if (timeEmesive < 3)
        {
            timeEmesive = 0;
        }
    }
}
