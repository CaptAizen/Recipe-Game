using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    public ScoreDisplay scoreDisplay;
    public CountdownBehavior countdownTimer;
    public Text HighscoreText;
    public float highscore = 0;

    // Start is called before the first frame update
    public void Start()
    {
        UpdateHighscoreText();
    }


    private void Update()
    {
        if (countdownTimer.CountdownTimer == 0)
        {
            UpdateHighscoreText();
        }
    }
    public void UpdateHighscoreText()
    {
        if (scoreDisplay.score > highscore && countdownTimer.CountdownTimer == 0)
        {
             highscore = scoreDisplay.score;
        }
        HighscoreText.text = "Highest Score: " + Mathf.Ceil(highscore).ToString();
    }
}
