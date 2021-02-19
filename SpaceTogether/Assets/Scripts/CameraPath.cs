using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPath : MonoBehaviour
{
    public float transitionTime = 2f;

    public CPC_CameraPath fromStartToOptions;
    public CPC_CameraPath fromOptionsToStart;

    public void StartToOptions()
    {
        fromStartToOptions.PlayPath(transitionTime);
    }

    public void OptionsToStart()
    {
        fromOptionsToStart.PlayPath(transitionTime);
    }
}
