using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Cell : MonoBehaviour
{
    public TextMeshProUGUI label;
    public Image image;
    public Button btn;
    public int rank;
    public TicTacToeManager ticTacToeManager;
    AudioManager audioManager;

    [Header("Click Sound")]
    [SerializeField] AudioClip clicked;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Filling Cells with Proper Turn 
    public void Brim()
    {

        if (TicTacToeManager.single)
        {
            if (ticTacToeManager.xTurn && !ticTacToeManager.gameOverCheck)
            {
                audioManager.PlayParticular(clicked);
                btn.interactable = false;
                label.text = ticTacToeManager.Response();
                image.sprite = ticTacToeManager.ResponseImg();
                Color color = ticTacToeManager.ResponseColor();
                color.a = 1f;
                image.color = color;
                ticTacToeManager.EditSkeleton(rank, 1);
                ticTacToeManager.Toggle();
                ticTacToeManager.Message();
            }
            else
            {
                Debug.Log("Don't even try");
            }

        }
        else 
        {
            if (!ticTacToeManager.gameOverCheck)
            {
                audioManager.PlayParticular(clicked);
                btn.interactable = false;
                label.text = ticTacToeManager.Response();
                image.sprite = ticTacToeManager.ResponseImg();
                Color color = ticTacToeManager.ResponseColor();
                color.a = 1f;
                image.color = color;
                ticTacToeManager.EditSkeleton(rank, 1);
                ticTacToeManager.Toggle();
                ticTacToeManager.Message();
            }
        }
    }
}
