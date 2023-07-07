using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChange : MonoBehaviour
{
    public float slowdownFactor = 0.05f;
    public float slowdownLeangth = 2f;

    bool paused;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void MoveSlowmotion(bool slowMo)
    {
        if (slowMo && (!paused))
        {
            Time.timeScale = slowdownFactor;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;

        }
        else if (!paused)
        {
            Time.timeScale = 3;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;

        }

    }

    public void Pause(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            paused = pause;
        }
        else
        {
            paused = pause;
        }
    }
    public bool getpaused()
    {
        return paused;

    }
}
