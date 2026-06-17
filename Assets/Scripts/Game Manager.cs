using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Playing Options
    [SerializeField] GameObject LDrago;
    [SerializeField] GameObject LDragoController;

    // Static Properties
    public static bool singlePlayer;
    public static bool dualPlayer;
    public static bool gameOver ;
    public static bool cosmic ;
    public static bool destructor ;

    // Scores 
    public static int redScore = 0;
    public static int blueScore = 0;


    private void Start()
    {
        if(singlePlayer)
        {
            LDrago.GetComponent<Automatic>().enabled = true;
            LDragoController.SetActive(false);
            LDrago.GetComponent<ManualControl>().enabled = false;

        }
        else if(dualPlayer)
        {
            LDrago.GetComponent<ManualControl>().enabled = true;
            LDragoController.SetActive(true);
            LDrago.GetComponent<Automatic>().enabled = false;

        }
    }

    public string NumberToString(int number)
    {
        string[] names = { "Zero", "One", "Two", "Three" };
        return names[number];
    }


}
