using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public bool paused;

    List<AudioSource> audioSources = new List<AudioSource>();

    public GameObject pauseCanvas;

    private AudioSource pauseAudio;

    private void Awake()
    {
        pauseAudio = GetComponent<AudioSource>();
        audioSources = FindObjectsOfType<AudioSource>().OfType<AudioSource>().ToList();

        audioSources.Remove(pauseAudio);
    }

    private void Start()
    {
        pauseAudio.Play();
        pauseAudio.Pause();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                UnPause();
            }
            else
            {
                Pause();
            }
        }
            
    }

    public void Pause()
    {
        paused = true;

        pauseAudio.UnPause();

        pauseCanvas.SetActive(true);

        Cursor.lockState = CursorLockMode.None;

        Time.timeScale = 0;

        foreach (var item in audioSources)
        {
            item.Pause();
        }


    }

    public void UnPause()
    {
        foreach (var item in audioSources)
        {
            item.UnPause();
        }

        Time.timeScale = 1;

        Cursor.lockState = CursorLockMode.Locked;

        pauseCanvas.SetActive(false);

        pauseAudio.Pause();

        paused = false;
    }
}
