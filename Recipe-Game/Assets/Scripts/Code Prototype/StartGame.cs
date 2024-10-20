using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public CountdownBehavior countdownTimer;
    public bool gameOn = false;

    private void OnMouseDown()
    {
        countdownTimer.StartCountdown();
        gameOn = true;
    }
}
