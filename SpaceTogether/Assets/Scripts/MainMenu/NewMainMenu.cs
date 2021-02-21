using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMainMenu : MonoBehaviour
{

    public GameObject controls;

    void Start()
    {
        controls.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenOptions()
    {

    }

    public void ExitOptions()
    {

    }
    public void OpenControls()
    {
        controls.SetActive(true);
    }

    public void CloseControls()
    {
        controls.SetActive(false);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
