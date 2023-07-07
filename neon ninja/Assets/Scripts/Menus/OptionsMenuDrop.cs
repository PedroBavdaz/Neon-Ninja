using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Resumebutton : MonoBehaviour
{
    bool paused = true;
    public TimeChange timeChange;
    public LeverLoader leverLoader;



    public void MenuUp()
    {
        paused = false;
        timeChange.Pause(paused);
    }

    public void PlayGame()
    {
        leverLoader.LoadNextLevel(0);
    }

    // Update is called once per frame
    void Start()
    {
        paused = true;
    }
}
