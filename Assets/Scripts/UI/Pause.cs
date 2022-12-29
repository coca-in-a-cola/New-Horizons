using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused = false;
    private void Update()
    { 

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isPaused)
            {
                isPaused = true;
                Time.timeScale = 0f;
                pauseMenu.SetActive(true);
            }
            else
            {
                isPaused = false;
                Time.timeScale = 1f;
                pauseMenu.SetActive(false);
            }
        }
    }
}
