using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairAnim : MonoBehaviour , InteractableObject
{
    Animation animation;

    public bool folded = true;

    public string unfold = "Chair";
    public string fold = "ChairFold";

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animation = GetComponent<Animation>();
    }

    public void Interact()
    {
        if (folded)
        {
            audioSource.Play();
            PlayAnim(unfold);
            folded = false;
        }
        else
        {
            audioSource.Play();
            PlayAnim(fold);
            folded = true;
        }
    }

    private void PlayAnim(string anim)
    {
        animation.Play(anim);
    }
}
