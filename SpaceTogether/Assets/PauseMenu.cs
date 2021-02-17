using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionsMenu;

    public void ShowOptions()
    {
        optionsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void ShowPause()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    private void OnDisable()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
}
