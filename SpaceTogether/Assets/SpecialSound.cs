using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialSound : MonoBehaviour
{
    AudioSource audioSource;
    

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
            GetComponent<Collider>().enabled = false;
        }
    }
}
