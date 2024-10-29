using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientMover : MonoBehaviour
{
    public IngredientGenerator ingredientGenerator;
    public CountdownBehavior countdownTimer;
    public StartGame startGame;
    
    public int ingredientIndex;
    public static int IngredientsClicked = 0;
    public static int PanIngredientLocationFinder;
    public float timeSpentOnPan = 0;

    public Vector3[] PanIngredientLocations = new Vector3[]
    {
        new Vector3((float)-1.46099997,(float)2.73000002,(float)1.19000006),
        new Vector3((float)-1.06900001,(float)2.73000002,(float)0.40200001),
        new Vector3((float)-0.690999985,(float)2.73000002,(float)1.13499999),
    };

  private void OnMouseDown()
    {
        if (countdownTimer.CountdownTimer > 0 && startGame.gameOn)
        {
            MoveIngredients();
        }
    }

    public void MoveIngredients()
    {
        PanIngredientLocationFinder = IngredientsClicked % 3;
        IngredientsClicked += 1;

        GameObject tempObj = Instantiate(gameObject);
        tempObj.name = "Ingredient " + IngredientsClicked;
        tempObj.transform.position = PanIngredientLocations[PanIngredientLocationFinder];
    }
   



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update ()
    {
        CheckPosition(this.gameObject);
    }

    void CheckPosition(GameObject gameObject)
    {
        foreach (Vector3 position in PanIngredientLocations)
        {
            if(gameObject.transform.position == position)
            {
                timeSpentOnPan += Time.deltaTime;
            }
        }
    }
}
