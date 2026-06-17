using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TicTacToeEvent : MonoBehaviour
{

    public void Mode(bool singleMode)
    {
        TicTacToeManager.single = singleMode;
        SceneManager.LoadScene(5);
    }

    public void LoadScreeen(int screenId)
    {
        SceneManager.LoadScene(screenId);
    }
    
}
