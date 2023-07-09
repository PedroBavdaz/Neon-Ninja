using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    ////////////////////////////////
    //Text Mesh for dysplay
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI highscoreText;


    ////////////////////////////////
    //actual values
    public int score = 0;
    int highscore = 0;
    public int wave = 0;


    // Start is called before the first frame update
    void Start()
    {

        scoreText.text = score.ToString() + " POINTS";
    }

    // Update is called once per frame
    void Update()
    {
        if ((Screen.orientation == ScreenOrientation.LandscapeLeft) || (Screen.orientation == ScreenOrientation.LandscapeRight))
        {
            transform.position = new Vector2(1250, 1075);
        }
        else if ((Screen.orientation == ScreenOrientation.Portrait) || (Screen.orientation == ScreenOrientation.PortraitUpsideDown))
        {
            transform.position = new Vector2(600, 2375);
        }
    }



    ////////////////////////////////
    //Adding values
    public void addPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " POINTS";
    }
    public void addhighscore()
    {
        highscore += 1;
        highscoreText.text = "Highscore: " + highscore.ToString();
    }
    public void addwave()
    {
        wave += 1;
        waveText.text = "Wave # " + wave.ToString();
    }
}
