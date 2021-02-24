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

        StartCoroutine(Finish());
    }

    IEnumerator Finish()
    {
        yield return new WaitForSeconds(20);

        ShowCredits();
    }

    public void ShowCredits()
    {
        credits.SetActive(true);
    }
}
