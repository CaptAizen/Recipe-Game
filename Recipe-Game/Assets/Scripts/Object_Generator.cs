using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Generator : MonoBehaviour
{
    public GameObject objectToGenerate;
    public int numberOfObjects = 5;
    public Vector3 spawnPosition = new Vector3 (0, 0, 0);
    public Vector3 spawnOffset = new Vector3(1, 0, 0);

    private bool objectsGenerated = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
