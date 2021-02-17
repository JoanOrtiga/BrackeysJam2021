using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource foot;
    public AudioClip[] footSteps;

    public void PlaySteps()
    {
        int randomIndex = Random.Range(0, 4);
        foot.clip = footSteps[randomIndex];
        foot.Play();
    }
}
