﻿using UnityEngine.Audio; 
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSounds[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach(AudioSounds s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch; 
        }
    }

    public void Play(string name){
        AudioSounds s = Array.Find(sounds, AudioSounds => AudioSounds.name == name);
        Debug.Log("Nombre: " + s.name);
        s.source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
