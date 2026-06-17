using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI redtext;
    [SerializeField] TextMeshProUGUI blueText;
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        redtext.text = gameManager.NumberToString(GameManager.redScore);
        blueText.text = gameManager.NumberToString(GameManager.blueScore);
    }
}
