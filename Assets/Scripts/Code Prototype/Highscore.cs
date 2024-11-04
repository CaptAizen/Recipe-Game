using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    // Reference to the ScoreDisplay script
    public ScoreDisplay scoreDisplay;
    // Reference to the CountdownBehavior script
    public CountdownBehavior countdownTimer;
    // UI Text element to display the high score
    public Text HighscoreText;
    // Variable to store the high score
    public float highscore = 0;

    // Start is called before the first frame update
    public void Start()
    {
        // Update the high score text at the start
        UpdateHighscoreText();
    }

    private void Update()
    {
        // Check if the countdown timer has reached zero
        if (countdownTimer.CountdownTimer == 0)
        {
            // Update the high score text
            UpdateHighscoreText();
        }
    }

    public void UpdateHighscoreText()
    {
        // Check if the current score is higher than the high score and the countdown timer is zero
        if (scoreDisplay.score > highscore && countdownTimer.CountdownTimer == 0)
        {
            // Update the high score
            highscore = scoreDisplay.score;
        }
        // Update the high score text UI element
        HighscoreText.text = "Highest Score: " + Mathf.Ceil(highscore).ToString();
    }
}
