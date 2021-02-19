using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWindow : MonoBehaviour
{
    public Transform door;
    public Transform endPos;

    float closeDistance = 0.1f;
    public float speed = 3f;

    public bool opening;

    public void Open()
    {
        door.position = Vector3.Lerp(door.position, endPos.position, speed * Time.deltaTime);

        if ((door.position - endPos.position).sqrMagnitude < closeDistance * closeDistance)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (opening)
        {
            Open();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            opening = true;
    }

    public void SetOpen()
    {
        opening = true;
    }
}
