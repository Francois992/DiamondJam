using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds = new Sound[10];

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        foreach (Sound s in sounds)
        {
            if (s.source == null)
            {
                s.source = Camera.main.gameObject.AddComponent<AudioSource>();
            }
            s.source.clip = s.clip;
            if (s.playOnAwake)
            {
                s.source.playOnAwake = true;
            }
            
            s.source.loop = s.loop;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }

        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }

        s.source.Stop();
    }

    [System.Serializable]
    public class Sound
    {
        public string name;

        public AudioClip clip;

        [HideInInspector] public AudioSource source;
        public bool playOnAwake;
        public bool loop;
    }
}
