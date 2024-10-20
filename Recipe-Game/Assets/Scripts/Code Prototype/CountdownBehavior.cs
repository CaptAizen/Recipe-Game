using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownBehavior : MonoBehaviour
{
    public float CountdownTimer = 60f;
    public Text timerText;
    private bool isCountingDown = false;

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
            if (CountdownTimer < 0)
            {
                CountdownTimer = 0;
            }

            timerText.text = "Time: " + Mathf.Ceil(CountdownTimer).ToString();
        }
    }
    public void StartCountdown()
    {
        isCountingDown = true;
    }
}
