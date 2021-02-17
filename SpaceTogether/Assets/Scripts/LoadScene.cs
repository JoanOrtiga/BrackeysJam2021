using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public int sceneToLoad;
    public GameObject LoadCanvas;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            StartCoroutine(LoadYourAsyncScene());
        }
    }


    IEnumerator LoadYourAsyncScene()
    {
        GameObject canvas = Instantiate(LoadCanvas);

        Image loadBar = null;



        for (int i = 0; i < canvas.transform.GetChild(0).childCount; i++)
        {

            if (canvas.transform.GetChild(0).GetChild(i).CompareTag("LoadBar"))
            {
                print("hola");
                loadBar = canvas.transform.GetChild(0).GetChild(i).GetComponent<Image>();
            }
        }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
        asyncLoad.allowSceneActivation = false;


        while (!asyncLoad.isDone)
        {
            while (!asyncLoad.isDone)
            {
                loadBar.fillAmount = asyncLoad.progress;

                if (asyncLoad.progress >= 0.9f)
                {
                    yield return new WaitForSeconds(2f);
                    asyncLoad.allowSceneActivation = true;
                }

                yield return null;
            }

        }
    }
}
