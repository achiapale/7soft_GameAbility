using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script che permette ai bottoni di cambiare scena

public class ButtonSelection : MonoBehaviour
{
    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void GameButton()
    {
        SceneManager.LoadScene(1);
    }

    public void GameOverButton()
    {
        SceneManager.LoadScene(2);
    }

    public void OptionsButton()
    {
        SceneManager.LoadScene(3);
    }

    public void TutorialButton()
    {
        SceneManager.LoadScene(4);
    }
  

    // Chiude il gioco

    public void QuitButton()
    {
        Application.Quit();
    }

}
