using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchStatements : MonoBehaviour
{
    
    public static int ClickCount = 0;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        ClickCount++;
        Transform panLocation;
        GameObject tmp = Instantiate(this.gameObject);
        Destroy(tmp.GetComponent<SwitchStatements>());

        switch (ClickCount)
        {
            case 1:
                tmp.name = "Pan Item 1:";
                panLocation = GameObject.Find("Position 1").transform;

                tmp.transform.localScale = new Vector3(1f, 1f, 1f);
                tmp.transform.position = panLocation.position;
                tmp.transform.rotation = panLocation.rotation;
                break;
            case 2:
                tmp.name = "Pan Item 2";
                panLocation = GameObject.Find("Position 2").transform;

                tmp.transform.position = panLocation.position;
                tmp.transform.rotation = panLocation.rotation;
                tmp.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            case 3:
                tmp.name = "Pan Item 3";
                panLocation = GameObject.Find("Position 3").transform;

                tmp.transform.position = panLocation.position;
                tmp.transform.rotation = panLocation.rotation;
                tmp.transform.localScale = new Vector3(1f, 1f, 1f);
                ClickCount = 0;
                break;
        }
    }
}

