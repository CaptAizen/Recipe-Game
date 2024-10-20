using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText;
    public float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }
    

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + Mathf.Ceil(score).ToString();
    }
}
