using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public void LoadStarSystem()
    {
        SceneManager.LoadScene("Star System");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu Scene");
    }
}
