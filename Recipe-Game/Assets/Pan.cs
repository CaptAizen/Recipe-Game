using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : MonoBehaviour
{
    float CountdownTimer = 60;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        if (CountdownTimer == 0)
        { 
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        CountdownTimer -= Time.deltaTime;
    }
}
