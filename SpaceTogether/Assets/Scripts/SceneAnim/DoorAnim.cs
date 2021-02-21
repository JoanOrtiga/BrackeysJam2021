using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnim : MonoBehaviour
{
    public Transform door;
    public Transform door2;
    public Transform startPos;
    public Transform start2Pos;
    public Transform endPos;
    public Transform end2Pos;

    public Material openMMaterial;
    public Material openFMaterial;
    public Material closedMMaterial;
    public Material closedFMaterial;

    public Renderer rendererM;
    public Renderer rendererF;

    public AudioSource audioSource;

    public float speed = 3f;
    public float margin = 0.001f;

    public bool opening;
    public bool moving = true;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        rendererF.material = closedFMaterial;
        rendererM.material = closedMMaterial;
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

    private void Update()
    {
        if (!moving)
            return;

        if (opening)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rendererF.material = openFMaterial;
            rendererM.material = openMMaterial;

            audioSource.Play();

            opening = true;
            moving = true;
        }
           
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            opening = false;
            moving = true;

            audioSource.Play();

            rendererF.material = closedFMaterial;
            rendererM.material = closedMMaterial;
        }
            
    }
}
