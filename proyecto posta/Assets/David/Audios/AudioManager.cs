using UnityEngine.Audio; 
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSounds[] sounds;
    static public float volume = 0.5f;
    // Start is called before the first frame update
    void Awake()
    {
        foreach(AudioSounds s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.volume = volume;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch; 
            s.source.loop = s.loop;
        }
    }

    public void setVolume(float Vol){
        volume = Vol;
    }

    public float getVolume(){
        return volume;
    }

    public void Play(string name){
        AudioSounds s = Array.Find(sounds, AudioSounds => AudioSounds.name == name);
        s.source.Play();
    }

    public void Stop(string name){
        AudioSounds s = Array.Find(sounds, AudioSounds => AudioSounds.name == name);
        s.source.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(AudioSounds s in sounds){
            s.volume = volume;
            s.source.volume = s.volume;
        }
    }
}
