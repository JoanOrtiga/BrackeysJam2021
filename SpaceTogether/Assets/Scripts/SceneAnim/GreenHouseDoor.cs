using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class GreenHouseDoor : MonoBehaviour
{
    public VisualEffect[] waterStem;

    public Transform door;
    public Transform door2;
    public Transform startPos;
    public Transform start2Pos;
    public Transform endPos;
    public Transform end2Pos;

    public float speed = 3f;

    public bool opening;

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
        {

            opening = true;
            EnableDoorStem();
        }
           
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DisableDoorStem();
            opening = false;
        }
            
    }

    private void Update()
    {
        if (opening)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    public void Open()
    {
        door.position = Vector3.Lerp(door.position, startPos.position, speed * Time.deltaTime);
        door2.position = Vector3.Lerp(door2.position, start2Pos.position, speed * Time.deltaTime);
    }

    public void Close()
    {
        door.position = Vector3.Lerp(door.position, endPos.position, speed * Time.deltaTime);
        door2.position = Vector3.Lerp(door2.position, end2Pos.position, speed * Time.deltaTime);
    }
}
