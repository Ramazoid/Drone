using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public List<AudioClip> clips;
    public AudioSource Player;
private static AudioPlayer INST;

    void Start()
    {
        INST = this;
        Player.clip = clips[0];
        Player.Play();
        
    }
   

    internal static void JumpTo(float jumpTime)
    {
        INST.Player.time = jumpTime;
    }
}
