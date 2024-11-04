using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
    {
        // References to other scripts
        StartGame game;
        CountdownBehavior countdownBehavior;
        // UI Text element to display the game over message
        public GameObject gameOverTextObject;

        // Start is called before the first frame update
        void Start()
        {
            // Find the CountdownBehavior script in the scene
            if (countdownBehavior == null)
            {
                countdownBehavior = FindObjectOfType<CountdownBehavior>();
            }
        }

        // Update is called once per frame
        void Update()
        {
            // Display the game over message if the countdown timer is zero
            if (countdownBehavior.CountdownTimer <= 0)
            {
                gameOverTextObject.SetActive(true);
            }
            // Hide the game over message if the countdown timer is running
            if (countdownBehavior.CountdownTimer > 0)
            {
                gameOverTextObject.SetActive(false);
            }

        if (countdownBehavior == null)
        {
            countdownBehavior = FindObjectOfType<CountdownBehavior>();
        }
    }
}
