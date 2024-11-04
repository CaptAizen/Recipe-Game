using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    // UI Text element to display the score
    public Text scoreText;
    // Variable to store the score
    public float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Update the score text at the start
        UpdateScoreText();
    }

    // Method to update the score text UI element
    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + Mathf.Ceil(score).ToString();
    }
}
