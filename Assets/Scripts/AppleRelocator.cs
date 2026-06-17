using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class AppleRelocator : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject playingPanel;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    Vector3 startingPosition;

    public int redScore;
    public int greenScore;
    public bool gameOver;
    private void Start()
    {
        redScore = 0;
        greenScore = 0;
        gameOver = false;
        gameOverPanel.SetActive(false);
        startingPosition = transform.position;
        AppleEnter();
    }

    private void FixedUpdate()
    {
        if(gameOver)
        {
            if(redScore > greenScore) {
                textMeshProUGUI.text = "Scarlet";
            }
            else
            {
                textMeshProUGUI.text = "Emerald";
            }
            playingPanel.SetActive(false);
            gameOverPanel.SetActive(true);
        }
    }

    public void AppleEnter()
    {
        transform.DOMoveX(0f, 2f).SetEase(Ease.OutExpo);
    }


    public void RespwanApple()
    {
        transform.DOScale(0.1f, 2.5f).SetEase(Ease.OutExpo).OnComplete(() =>
        {
            transform.parent = null;
            transform.position = startingPosition;
            transform.DOScale(1f, 0.1f).OnComplete(() =>
            {
                AppleEnter();
            });
        });
    }
}
