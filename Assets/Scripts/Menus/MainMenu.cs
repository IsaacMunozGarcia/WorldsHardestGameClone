using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private int scene;
    public void OnPlayButtonClick()
    {
        SceneManager.LoadScene(scene);
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
}
