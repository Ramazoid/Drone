using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneCamScreen : MonoBehaviour
{
    public Camera droneCam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RenderTexture tex = new RenderTexture(512,512,24);
        droneCam.targetTexture = tex;
        droneCam.Render();
        droneCam.targetTexture = null;
        GetComponent<Renderer>().material.mainTexture = tex;
        
    }
}
