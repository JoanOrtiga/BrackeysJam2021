using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlace : MonoBehaviour
{
    [HideInInspector]
    public Vector3 initialPosition;
    [HideInInspector]
    public Quaternion initialRotation;


    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
