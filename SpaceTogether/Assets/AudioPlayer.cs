using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource foot;
  //  public AudioClip[] footSteps;
    public Sound[] footSteps;

    public void PlaySteps()
    {
        int randomIndex = Random.Range(0, 5);

        foot.clip = footSteps[randomIndex].clip;
        foot.pitch = footSteps[randomIndex].pitch;
        foot.volume = footSteps[randomIndex].volume;

        foot.Play();
    }
}
