using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void QuitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void Continue()
    {
    }

    public void GotoMenu()
    {
        var currentScene=SceneManager.GetActiveScene().name;
        TranslationManager.Instance.Transition(currentScene,"Menu");
    }
}
