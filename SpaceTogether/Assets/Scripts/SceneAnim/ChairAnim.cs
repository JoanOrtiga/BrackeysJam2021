using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairAnim : MonoBehaviour , InteractableObject
{
    Animation animation;

    public bool folded = true;

    public string unfold = "Chair";
    public string fold = "ChairFold";

    private void Awake()
    {
        animation = GetComponent<Animation>();
    }

    public void Interact()
    {
        if (folded)
        {
            PlayAnim(unfold);
            folded = false;
        }
        else
        {
            PlayAnim(fold);
            folded = true;
        }
    }

    private void PlayAnim(string anim)
    {
        animation.Play(anim);
    }
}
