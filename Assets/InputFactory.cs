using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.Events;

public class InputFactory : MonoBehaviour
{
    public MonoBehaviour acceptor;
   
    public UnityEvent frontAction;
   
    public UnityEvent leftAction;
   
    public string Right;
    public UnityEvent rightAction;
   
    public string Down;
    public UnityEvent backAction;
    public UnityEvent elevateAction;
    public UnityEvent releaseAction;
    private Tutorial tutor;

    void Start()
    {
        tutor = FindObjectOfType<Tutorial>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)) { leftAction.Invoke(); }
        if(Input.GetKeyUp(KeyCode.LeftArrow)) { releaseAction.Invoke(); }
        if(Input.GetKey(KeyCode.RightArrow)) { rightAction.Invoke(); }
        if(Input.GetKeyUp(KeyCode.RightArrow)) { releaseAction.Invoke(); }
        if(Input.GetKey(KeyCode.UpArrow)) { frontAction.Invoke(); }
        if(Input.GetKeyUp(KeyCode.UpArrow)) { releaseAction.Invoke(); }
        if(Input.GetKey(KeyCode.Space)) { elevateAction.Invoke(); }
        if(Input.GetKeyUp(KeyCode.Space)) { elevateAction.Invoke(); }
        if(Input.GetKey(KeyCode.DownArrow)) { backAction.Invoke(); }
        if(Input.GetKeyUp(KeyCode.DownArrow)) { releaseAction.Invoke(); }
    }
    
}

