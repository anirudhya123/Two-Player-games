using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] GameObject levelWinPanel;
    [SerializeField] TextMeshProUGUI levelWinner;
    [SerializeField] GameObject finalWinPanel;
    [SerializeField] TextMeshProUGUI finalWinner;

    [Header("Sound Effect")]
    [SerializeField] AudioClip[] gameover;
        AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    void Update()
    {
        if (GameManager.gameOver)
        {
            if (GameManager.destructor)
            {

                if (GameManager.blueScore + 1 == 3)
                {
                    finalWinner.text = "Mr. Moon";
                    levelWinPanel.SetActive(false);
                    finalWinPanel.SetActive(true);
                    audioManager.PlayParticular(gameover[0]);
                    Destroy(gameObject.GetComponent<GameOver>());
                }
                else
                {
                    GameManager.blueScore += 1;
                    levelWinner.text = "Moon win";
                    finalWinPanel.SetActive(false);
                    levelWinPanel.SetActive(true);
                    audioManager.PlayParticular(gameover[1]);
                    Destroy(gameObject.GetComponent<GameOver>());

                }
            }
            else if (GameManager.cosmic)
            {
                if (GameManager.redScore + 1 == 3)
                {
                    finalWinner.text = "Mr. Sun";
                    levelWinPanel.SetActive(false);
                    finalWinPanel.SetActive(true);
                    audioManager.PlayParticular(gameover[0]);
                    Destroy(gameObject.GetComponent<GameOver>());
                }
                else
                {

                    GameManager.redScore += 1;
                    levelWinner.text = "Sun win";
                    finalWinPanel.SetActive(false);
                    levelWinPanel.SetActive(true);
                    audioManager.PlayParticular(gameover[1]);
                    Destroy(gameObject.GetComponent<GameOver>());
                }


            }

        }
    }
}
