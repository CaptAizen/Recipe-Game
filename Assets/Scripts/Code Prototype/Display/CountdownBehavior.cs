using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownBehavior : MonoBehaviour
{
    public float CountdownTimer = 60f;
    public Text timerText;
    private bool isCountingDown = false;
    public ScoreAdder scoreAdder; // Reference to ScoreAdder
    public ScoreDisplay scoreDisplay; // Reference to ScoreDisplay
    public Highscore highScoreDisplay; // Reference to HighScoreDisplay

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "Time: " + Mathf.Ceil(CountdownTimer).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCountingDown && CountdownTimer > 0)
        {
            CountdownTimer -= Time.deltaTime;
            if (CountdownTimer <= 0)
            {
                CountdownTimer = 0;
                scoreAdder.ClearPan(); // Clear the pan when the timer reaches zero
                CheckAndSetHighScore(); // Check and set the high score before resetting the score
                ResetScore(); // Reset the score when the timer reaches zero
            }

            timerText.text = "Time: " + Mathf.Ceil(CountdownTimer).ToString();
        }
    }

    public void StartCountdown()
    {
        isCountingDown = true;
    }

    void CheckAndSetHighScore()
    {
        if (scoreDisplay.score > highScoreDisplay.highscore)
        {
            highScoreDisplay.highscore = scoreDisplay.score;
            highScoreDisplay.UpdateHighscoreText();
        }
    }

    void ResetScore()
    {
        scoreDisplay.score = 0;
        scoreDisplay.UpdateScoreText();
    }
}
