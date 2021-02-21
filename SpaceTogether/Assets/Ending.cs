using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    Animation spaceShip;
    public GameObject credits;

    public void End()
    {
        spaceShip.Play();

        ShowCredits();
    }

    public void ShowCredits()
    {

    }
}
