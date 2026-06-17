using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public class TicTacToeBot : MonoBehaviour
{
    TicTacToeManager manager;
    

    private void Start()
    {
        manager = GetComponent<TicTacToeManager>();
    }

    public void AutomaticReaction(Cell[] cells)
    {
        int random;
        if(Robot() < 0)
        {
            if (manager.board.skeleton[4] == 0 ) { random = 4; }
            else
                random = Random.Range(0, cells.Length);
        }
        else
        {
            random = Robot();
        }

        if (cells[random].btn.interactable == true)
        {
            cells[random].btn.interactable = false;
            cells[random].label.text = manager.Response();
            cells[random].image.sprite = manager.ResponseImg();
            Color color = manager.ResponseColor();
            color.a = 1f;
            cells[random].image.color = color;
            manager.EditSkeleton(cells[random].rank, -1);
            manager.Toggle();
            manager.Message();
        }
        else
        {
            AutomaticReaction(cells);
        }
    }

    public int Robot()
    {
        // Attack Check
        if(Check(-1) != -1) { return Check(-1); }

        // Defence Check
        if(Check(1) != -1) { return Check(1); }

        // Check turn 

        return -1;
    }

    private bool Test(int firstIndex, int secondIndex, int element)
    {

        if (manager.board.skeleton[firstIndex] == element && manager.board.skeleton[secondIndex] == element)
        {
            return true;
        }

        return false;
    }

    private bool Empty(int index)
    {
        if (manager.board.skeleton[index] == 0)
        {
            return true;
        }
        return false;
    }

    private int Check(int id)
    {

        // Horizontal 

        for (int i = 0; i <= 6; i += 3)
        {
            if (Test(i, i + 1, id) && Empty(i+2))
            {
                return i + 2;
            }
            if (Test(i, i + 2, id) && Empty(i+1))
            {
                return i + 1;
            }
            if (Test(i + 1, i + 2, id) && Empty(i))
            {
                return i;
            }

        }

        // Vertical

        for (int i = 0; i <= 2; i += 1)
        {
            if (Test(i, i + 3, id) && Empty(i + 6))
            {
                return i + 6;
            }
            if (Test(i, i + 6, id) && Empty(i + 3))
            {
                return i + 3;
            }
            if (Test(i + 3, i + 6, id) && Empty(i))
            {
                return i;
            }

        }

        // Diagonal 
        if(Test(0,4, id) && Empty(8)) { return 8; }
        if(Test(0,8, id) && Empty(4)) { return 4; }
        if(Test(4,8, id) && Empty(0)) { return 0; }
        
        if(Test(2,4, id) && Empty(6)) { return 6; }
        if(Test(2,6, id) && Empty(4)) { return 4; }
        if(Test(4,6, id) && Empty(2)) { return 2; }


        // No Position

        return -1;
    }
   

}
