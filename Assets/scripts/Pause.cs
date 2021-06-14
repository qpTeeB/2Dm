using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject Menu;
    public bool IfPause = false;


    void Update()
    {
      /* if (IfPause)
        {
            StartPause();
        } 
       else if (!IfPause)
        {
            Resume();
        }*/
    }

    public void StartPause()
    {
        pauseButton.SetActive(false);
        Menu.SetActive(true);
        Time.timeScale = 0f;
        IfPause = true;
    }

    public void Resume()
    {
        pauseButton.SetActive(true);
        Menu.SetActive(false);
        Time.timeScale = 1f;
        IfPause = false;
    }

    public void Restart()
    {

    }
    public void Exit()
    {

    }
}
