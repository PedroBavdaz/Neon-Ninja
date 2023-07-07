using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameSettings : MonoBehaviour
{
    bool paused = true;
    public TimeChange timeChange;
    public LeverLoader leverLoader;



    public void MenuUp()
    {
        paused = false;
        timeChange.Pause(paused);
    }

    public void MainMenu()
    {

        leverLoader.LoadNextLevel(0);
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Start()
    {
        paused = true;
    }
}
