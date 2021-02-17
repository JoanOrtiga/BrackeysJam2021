using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public bool paused;

    List<AudioSource> audioSource = new List<AudioSource>();

    public GameObject pauseCanvas;

    private void Awake()
    {
        audioSource = FindObjectsOfType<AudioSource>().OfType<AudioSource>().ToList();
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

        pauseCanvas.SetActive(true);

        Cursor.lockState = CursorLockMode.None;

        Time.timeScale = 0;

        foreach (var item in audioSource)
        {
            item.Pause();
        }


    }

    public void UnPause()
    {
        foreach (var item in audioSource)
        {
            item.UnPause();
        }

        Time.timeScale = 1;

        Cursor.lockState = CursorLockMode.Locked;

        pauseCanvas.SetActive(false);

        paused = false;
    }
}
