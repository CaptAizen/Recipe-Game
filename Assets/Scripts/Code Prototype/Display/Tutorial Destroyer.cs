using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDestroyer : MonoBehaviour
{
    StartGame game;
    public GameObject Tutorial;
    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<StartGame>();
    }

    // Update is called once per frame
    void Update()
    {
        if(game.gameOn)
        {
            Tutorial.SetActive(false);
        }
    }
}
