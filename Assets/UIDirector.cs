using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIDirector : MonoBehaviour
{
    private static UIDirector INST;
    public UITween[] panels;

    public void Show(string panelName)
    {
        if (panels.Count() == 0) Collect();
        print("--------showing:" + panelName);
        UITween panel = Array.Find(panels,(p) =>{ return p.name == panelName; });
        panel.go = true;
    }

    private void Collect()
    {
        panels = GameObject.FindObjectsByType<UITween>(FindObjectsSortMode.None);
    }

    internal void Hide(string panelName)
    {
        UITween panel = Array.Find(panels, (p) => { return p.name == panelName; });
        panel.swich();
        panel.go = true;

    }

    private void Awake()
    {
        panels = GameObject.FindObjectsByType<UITween>(FindObjectsSortMode.None);
    }
    void Start()
    {
        
        Array.ForEach(panels, (p) => p.goStart());
    }
    
    void Update()
    {
        
    }
}
