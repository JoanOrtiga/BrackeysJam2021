using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class GreenHouseDoor : MonoBehaviour
{
    public VisualEffect[] waterStem;

    public void DisableDoorStem()
    {
        foreach (var item in waterStem)
        {
            item.SetBool("DoorEnabled", true);
        }
    }

    public void EnableDoorStem()
    {
        foreach (var item in waterStem)
        {
            item.SetBool("DoorEnabled", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            EnableDoorStem();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            DisableDoorStem();
    }
}
