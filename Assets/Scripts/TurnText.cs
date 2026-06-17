using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnText : MonoBehaviour
{
    TextMeshProUGUI textMeshProUGUI;
    public TicTacToeManager ticTacToeManager;
    string[] xLines = { "Go Ahead, X!", "X, Step Up!", "Strategize, X", "X, Choose Wisely", "X, It’s All Yours!" };
    string[] oLines = { "Bring It On, O!", "O, Show Your Skills!", "Think, O, Think", "O, Go for It!", "O, Make It Count!" };
    private void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        int random = Random.Range(0, xLines.Length);
        if (ticTacToeManager.Response() == "X")
            textMeshProUGUI.text = xLines[random];
        else
            textMeshProUGUI.text = oLines[random];
    }
}
