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

    AudioSource audioSource;

    public float speed = 3f;
    private float margin = 0.002f;

    public bool opening;
    public bool moving = true;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
            moving = true;
            opening = true;
            EnableDoorStem();

            audioSource.Play();
        }
           
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DisableDoorStem();
            opening = false;
            moving = true;

            audioSource.Play();
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

        if ((door2.position - start2Pos.position).sqrMagnitude < margin * margin)
        {
            moving = false;
        }
    }

    public void Close()
    {
        door.position = Vector3.Lerp(door.position, endPos.position, speed * Time.deltaTime);
        door2.position = Vector3.Lerp(door2.position, end2Pos.position, speed * Time.deltaTime);

        if ((door2.position - end2Pos.position).sqrMagnitude < margin * margin)
        {
            moving = false;
        }
    }
}
