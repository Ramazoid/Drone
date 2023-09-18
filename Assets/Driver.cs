using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Driver : MonoBehaviour
{

    public Transform DroneRoot;
    private Rigidbody DroneRig;
    public Transform DroneBody;
    private Vector3 acceleration;
    private Vector3 lastVelocity;
    public Quaternion newAngle;
    private float rootY;
    public bool rotaDone;
    private UIDirector uidirector;
    private Tutorial tutor;

    void Start()
    {
        DroneRig = DroneRoot.GetComponent<Rigidbody>();
        newAngle = Quaternion.identity;
        rootY = DroneRoot.rotation.eulerAngles.y;
        uidirector= FindObjectOfType<UIDirector>();
        tutor = FindObjectOfType<Tutorial>();
    }




    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            //Debug.DrawRay(DroneRoot.position, DroneRoot.up * 10, Color.blue);
        }
        else
        {

        }

        if (DroneRig != null)
        {
            acceleration = (DroneRig.velocity - lastVelocity) / Time.fixedDeltaTime;
            //print("acceleration="+acceleration.magnitude);
            lastVelocity = DroneRig.velocity;
        }

        DroneBody.localRotation = Quaternion.Lerp(DroneBody.localRotation, newAngle, 0.02f);
        
        DroneRoot.rotation = Quaternion.Euler(0, rootY, 0);
        if (DroneRig.transform.position.y < 1)
        {
            
            Elevate();
        }
    }

    public void ReleaseKey()
    {
        rotaDone = false;
        DroneRig.useGravity = true;
        newAngle = Quaternion.EulerAngles(0, 0, 0);
        DroneRig.useGravity = false;
    }

    public void Elevate()
    {
        //tutor.Show(2);
        if(DroneRig.transform.position.y<25)
        DroneRig.AddForce(Vector3.up * 50, ForceMode.Acceleration);
        else
            DroneRig.useGravity = true;
    }
    public void GoForward()
    {
        DroneRig.useGravity = false;
       
        newAngle = Quaternion.EulerAngles(20, 0, 0);
        Vector3 dir = Vector3.ProjectOnPlane(DroneRoot.forward, DroneRoot.up);
        DroneRig.AddForce(dir * 10, ForceMode.Acceleration);
    }
    public void GoLeft()
    {
        DroneRig.useGravity = false;
        newAngle = Quaternion.EulerAngles(0, 0, 20);

        //DroneRoot.Rotate(0, -1, 0);
        rootY--;

    }
    public void GoRight()
    {
        DroneRig.useGravity = false;
        newAngle = Quaternion.EulerAngles(0, 0, -20);

        rootY++;

    }
    public void GoBackward()
    {
        DroneRig.useGravity = true;
        newAngle = Quaternion.EulerAngles(-20, 0, 0);
        Vector3 dir = Vector3.ProjectOnPlane(-DroneRoot.forward, DroneRoot.up);
        DroneRig.AddForce(dir * 10, ForceMode.Force);
    }
}