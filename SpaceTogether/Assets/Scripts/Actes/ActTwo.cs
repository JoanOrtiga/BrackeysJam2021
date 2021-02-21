using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ActTwo : MonoBehaviour
{
    private Animator anim;
    private float time;
    bool finishRadio = false;



    void Start()
    {
        anim = GetComponent<Animator>();

    }

   
    void Update()
    {
        if (finishRadio == true)
        {
            time += Time.deltaTime;
        }
    }

    public void finishRadioWithCode()
    {
        anim.SetBool("FinishRadio", true);
        if (time > 4)
        {
            //LOAD SCENE
           
        }
        
    }

    public void finishRadioWithOutCode()
    {
        anim.SetBool("FinishRadio", true);
        transform.Rotate(0, 180, 0);
    }
}
