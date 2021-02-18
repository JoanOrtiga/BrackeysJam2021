using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEvents : MonoBehaviour
{
    public bool havePills = false;
    public bool seenFamilyPhoto = false;

    public bool HavePills() { return havePills; }
    public bool SeenFamilyPhoto() { return seenFamilyPhoto; }
}
