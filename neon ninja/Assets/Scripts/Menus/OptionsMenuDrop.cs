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

    void Update()
    {
        if ((Screen.orientation == ScreenOrientation.LandscapeLeft) || (Screen.orientation == ScreenOrientation.LandscapeRight))
        {
            transform.position = new Vector2(100, 0);
        }
        else if ((Screen.orientation == ScreenOrientation.Portrait) || (Screen.orientation == ScreenOrientation.PortraitUpsideDown))
        {
            transform.position = new Vector2(100, 2375);
        }
    }
}
