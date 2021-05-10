using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void gameStart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitGame ()
    {
        Debug.Log("Thanks for playing!");
        Application.Quit();
    }

    public void newGame ()
    {
        Debug.Log("New Game");
        SceneManager.LoadScene(0);
    }
}
