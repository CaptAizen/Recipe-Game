using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDisplay : MonoBehaviour
{
    public float CountdownTimer = 60f;
    public TextAlignment timerText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CountdownTimer > 0)
        { 
            CountdownTimer -= Time.deltaTime;
        }
        else
        {
            CountdownTimer = 0;
        }

        timerText.text = "Time: " + MathfCeil(CountdownTimer).ToString();
    }
}
