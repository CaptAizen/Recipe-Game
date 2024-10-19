using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.FilePathAttribute;
using static UnityEngine.Rendering.DebugUI;

public class PanBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        void OnMouseDown()
        {
            ExecuteOnClick();
        }

        void ExecuteOnClick()
        {
            Debug.Log("Game object clicked!");
        }



    }
    void OnMouseDown()
    {
        ExecuteOnClick();
    }

    void ExecuteOnClick()
    {
        Debug.Log("Game object clicked!");
    }
}
