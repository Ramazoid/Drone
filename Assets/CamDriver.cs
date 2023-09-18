using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamDriver : MonoBehaviour
{
    public Transform DroneRoot;
    public float distance;
    public float elevate;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = DroneRoot.position - DroneRoot.forward * distance+Vector3.up*elevate;

        transform.LookAt(DroneRoot);

    }
}
