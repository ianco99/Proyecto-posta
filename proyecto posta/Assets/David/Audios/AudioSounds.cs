﻿using UnityEngine.Audio; 
using UnityEngine;

[System.Serializable]
public class AudioSounds 
{
    public AudioClip clip;

    public string name;

    [Range(0f,1f)]
    public float volume;

    [Range(.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;


}
