using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using Random = UnityEngine.Random;
public class AudioMenager : MonoBehaviour
{
    public Sound[] sounds;
    private int rand;
    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(200, 600);
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = 1f;
            s.source.loop = s.loop;
        }
        PlaySound("Main");
        
    }


    public void PlaySound(string name)
    {
        Sound currSound=Array.Find(sounds, sound => sound.name == name);
        currSound.source.Play();
    }
    // Update is called once per frame
    void Update()
    {
    }
}
