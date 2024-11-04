using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDestroyer : MonoBehaviour
{
    // Reference to the StartGame script
    StartGame game;
    // Reference to the Tutorial game object
    public GameObject Tutorial;

    // Start is called before the first frame update
    void Start()
    {
        // Find the StartGame script in the scene
        game = FindObjectOfType<StartGame>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the game has started
        if (game.gameOn)
        {
            // Deactivate the Tutorial game object
            Tutorial.SetActive(false);
        }
    }
}
