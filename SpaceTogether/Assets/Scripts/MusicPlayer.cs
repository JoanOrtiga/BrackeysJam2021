using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public Sound[] songs;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySong(string songName)
    {
        Sound playSong = null;

        foreach (var item in songs)
        {
            if(item.name == songName)
            {
                playSong = item;
            }
        }

        audioSource.clip = playSong.clip;
        audioSource.Play();
    }
}
