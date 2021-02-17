using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private float musicVolume = 1f;



    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

        }
    }
    private void Update()
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = s.volume;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    public void Mute(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Pause();
    }
    public void Resume(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.UnPause();
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
    public void MainVolume(float value)
    {
        Sound s = Array.Find(sounds, sound => sound.name == "MenuSong");
        Sound ss = Array.Find(sounds, sound => sound.name == "InGameSong");
        s.volume = value;
        ss.volume = value;

    }

    public void Volume(string name, float value)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.volume = value;
       

    }

    public void SFXVolume(float value)
    {
        foreach (Sound s in sounds)
        {
            if (s.isSFX)
            {
                s.volume = value;
            }
        }
    }
}