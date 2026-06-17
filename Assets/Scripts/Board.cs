using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Board : MonoBehaviour
{
    public GameObject cellPrefab;
    public Cell[] cells = new Cell[9];
    public int[] skeleton = new int[9];
    public TicTacToeManager ticTacToeManager;

    public int[] winningCells = { -1, -1, -1 };


    // Dynamically Generating the Cells into their position
    public void Generate(TicTacToeManager ticTacToeManager)
    {
        for(int i =  0; i < 9; i++) {
            GameObject cell = Instantiate(cellPrefab,transform);
            cells[i] = cell.GetComponent<Cell>();
            cells[i].ticTacToeManager = ticTacToeManager;
            cells[i].rank = i;
            skeleton[i] = 0;
        }
    }

    public bool GameOver()
    {
        int i = 0;


        for(i = 0; i <= 6; i+=3) {
            if (!Compare(i, i + 1))
                continue;
            if(!Compare(i, i + 2))
                continue;

            winningCells[0] = i;
            winningCells[1] = i+1;
            winningCells[2] = i+2;
            return true;
        }
        
        
        for(i = 0; i <= 2; i++) {
            if (!Compare(i, i + 3))
                continue;
            if(!Compare(i, i + 6))
                continue;

            winningCells[0] = i;
            winningCells[1] = i + 3;
            winningCells[2] = i + 6;
            return true;
        }

        if(Compare(0,4) && Compare(0,8))
        {
            winningCells[0] = 0;
            winningCells[1] = 4;
            winningCells[2] = 8;
            return true;
        }

        if(Compare(2,4) && Compare(2,6))
        {
            winningCells[0] = 2;
            winningCells[1] = 4;
            winningCells[2] = 6;
            return true;
        }

        return false;
    }

    private bool Compare(int firstIndex, int secondIndex)
    {
        string firstNum = cells[firstIndex].label.text;
        string secondNum = cells[secondIndex].label.text;

        if (firstNum == "" || secondNum == "")
            return false;

        if(firstNum == secondNum)
            return true;
        else
            return false;
    }

    public void Refresh()
    {
        foreach (Cell cell in cells)
        {
            cell.GetComponent<Image>().color = Color.black;
            cell.label.text = "";
            cell.image.sprite = null;
            Color color = cell.image.color;
            color.a = 0f;
            cell.image.color = color;
            cell.btn.interactable = true;
        }
        for (int i = 0;i < skeleton.Length;i++) {
            skeleton[i] = 0;
        }
        ticTacToeManager.gameOverCheck = false;
        ticTacToeManager.drawCheck = false;
        ticTacToeManager.xTurn = true;
        ticTacToeManager.Message();
        ticTacToeManager.ScoreUpdate();
    }

    public void WinningCells()
    {
        foreach (Cell cell in cells)
        {
            for (int i = 0; i < winningCells.Length;i++) {
                if(cell.rank == winningCells[i])
                {
                    //cell.GetComponent<Image>().color = new Color(255,135,0,255);
                    cell.GetComponent<Image>().DOColor(new Color(255, 135, 0, 255), 0.2f).SetEase(Ease.InOutQuint);
                    cell.image.DOColor(Color.white,0.2f).SetEase(Ease.InOutQuint);
                    //cell.image.color = Color.white;
                }
            }
        }
    }
    
  }
