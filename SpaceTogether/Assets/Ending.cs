using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    Animation spaceShip;

    public void End()
    {
        spaceShip.Play();

        ShowCredits();
    }

    public void ShowCredits()
    {

    }
}
