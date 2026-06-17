using System;
using System.Collections;

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TicTacToeManager : MonoBehaviour
{
    public Board board;
    public GameObject winner;

    public Sprite cross;
    public Sprite circle;

    public int xScore = 0;
    public int oScore = 0;

    public TextMeshProUGUI xScoreText;
    public TextMeshProUGUI oScoreText;

    TicTacToeBot bot;
    public static bool single = false;
    public bool xTurn = true;
    private int turnCount = 0;

    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    string[] xLines = { "Go Ahead, X!", "X, Step Up!", "Strategize, X", "X, Choose Wisely", "X, It’s All Yours!" };
    string[] oLines = { "Bring It On, O!", "O, Show Your Skills!", "Think, O, Think", "O, Go for It!", "O, Make It Count!" };
    string[] xWinningMessage = { "X Takes the Victory!", "X, You Did It!", "Hooray! X Wins!", "X, You Nailed It!", "X, Your Strategy Wins!" };
    string[] oWinningMessage = { "O Claims the Win!", "O Dominates the Board!", "O, You Rock!", "O, Fantastic Game!", "O Conquers All!" };
    string[] drawMessage = { "It's a Draw! Well Played!",
                                "No Winner This Time! It's a Tie!",
                                "Stalemate! Both Played Well!",
                                "A Tie! Great Game, Everyone!","It's a Draw! Let's Play Again!" };


    public bool gameOverCheck = false;
    public bool drawCheck = false;

    [Header("Sound Tracks")]
    public AudioClip sound;
    public AudioClip hitSound;
    AudioManager audioManager;

    private void Awake()
    {
        board.Generate(this); // Building the Grid 
    }

    private void Start()
    {
        bot = GetComponent<TicTacToeBot>();
        audioManager = FindObjectOfType<AudioManager>();
        xScore = 0;
        oScore = 0;
        Message();
        ScoreUpdate();
    }

    // Manages no of turns and change of turn
    public void Toggle()
    {
        /*

        // Visualize Array

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < board.skeleton.Length; i++)
        {
            sb.Append(board.skeleton[i].ToString());
        }
        Debug.Log(sb.ToString());

        */
        turnCount++;

        bool result = board.GameOver();
        

        if (result || turnCount == 9)
        {
            gameOverCheck = true;
            drawCheck = result;
            StartCoroutine(Conclude(result));
            return;
        }
            
        xTurn = !xTurn;


        if(!xTurn && single)
        {
            StartCoroutine(Delay());
        }

    }


    // returns current turn
    public string Response()
    {
        if (xTurn)
        {
            return "X";
        }
        else { return "O"; }    
    }

    public Sprite ResponseImg()
    {
        if (xTurn)
            return cross;
        else
            return circle;
    }

    public Color ResponseColor() {
        if (xTurn)
        {
            Color32 color = new(65, 195, 131,255);
            return color;

        }
        else {
            Color32 color = new(194, 65, 105, 255);
            return color;
             }
    
    }

    
    // Activates Gameover Panel
    private IEnumerator Conclude(bool result) {

        if (result)
        {
            if(xTurn)
            {
                xScore++;
            }
            else
            {
                oScore++;
            }
            board.WinningCells();
        }
        


        WaitForSeconds wait = new WaitForSeconds(5f);
        yield return wait;
        board.Refresh();
        turnCount = 0;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);

        bot.AutomaticReaction(board.cells);
        audioManager.PlayParticular(hitSound);

    }

    public void EditSkeleton(int rank, int fill)
    {
        board.skeleton[rank] = fill;
    }

    public void Message()
    {

        int random = UnityEngine.Random.Range(0, xLines.Length);

        if (gameOverCheck)
        {
            if (!drawCheck)
                textMeshProUGUI.text = drawMessage[random];
            else if (xTurn)
            {
                textMeshProUGUI.text = xWinningMessage[random];
                audioManager.PlayParticular(sound);
            }

            else
            {
                textMeshProUGUI.text = oWinningMessage[random];
                audioManager.PlayParticular(sound);

            }
        }
        else
        {
            if (xTurn)
                textMeshProUGUI.text = xLines[random];
            else
                textMeshProUGUI.text = oLines[random];
        }
    }

    public void ScoreUpdate()
    {
        xScoreText.text = xScore.ToString();
        oScoreText.text = oScore.ToString();
    }
    
}
