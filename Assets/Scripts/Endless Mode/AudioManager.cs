
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    private void Awake()
    {
       
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;


        }
    }
    private void Start()
    {
        Play("Theme");
    }

    public void Play(string Name)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == Name);
        if (s == null)
        {
            Debug.LogWarning("Error " + Name + " not found!");
            return;
        }
        s.source.Play();
    }
}

   
