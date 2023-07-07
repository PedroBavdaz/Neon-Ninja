using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public LeverLoader leverLoader;

    public Animator transition;
    GameObject Crossfade;

    public void PlayGame()
    {
        leverLoader.LoadNextLevel(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
