using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour , InteractableObject
{
    public GameObject toActive;

    private bool active = false;

    public void Interact()
    {
        if (!active)
        {
            active = true;
            toActive.SetActive(true);

            StartCoroutine(DeActivate());
        }
    }

    IEnumerator DeActivate()
    {
        yield return new WaitForSeconds(4);

        active = false;
        toActive.SetActive(false);
    }
}
