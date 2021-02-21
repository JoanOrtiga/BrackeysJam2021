using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource foot;
  //  public AudioClip[] footSteps;
    public AudioClip[] footSteps;

    public void PlaySteps()
    {
        int randomIndex = Random.Range(0, footSteps.Length);

        foot.clip = footSteps[randomIndex];
        foot.Play();
    }
}
