using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    StartGame game;
    CountdownBehavior countdownBehavior;
    public GameObject gameOverTextObject;

    // Start is called before the first frame update
    void Start()
    {
        if (countdownBehavior == null)
        {
            countdownBehavior = FindObjectOfType<CountdownBehavior>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (countdownBehavior.CountdownTimer <= 0)
        {
           gameOverTextObject.SetActive(true);
        }
        if (countdownBehavior.CountdownTimer > 0)
        {
            gameOverTextObject.SetActive(false);
        }
    }
}
