using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{
    public void StartGame()
    {
        SceneManager.LoadScene("TestLevel");
    }

    public void CreditsMenu()
    {
        SceneManager.LoadScene("CreditsMenu");
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
