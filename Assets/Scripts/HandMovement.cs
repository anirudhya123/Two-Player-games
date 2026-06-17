using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class HandMovement : MonoBehaviour
{
    [SerializeField] Ease movementEase;
    float screenThresholdLow;
    float screenThresholdHigh;
    private float iniY;
    public float finalY;
    private AppleRelocator relocator;

    private bool handReached;
    private void Start()
    {
        handReached = false;
        if(gameObject.tag == "GreenHand")
        {
            screenThresholdLow = Screen.height/2;
            screenThresholdHigh = Screen.height;
        }
        else
        {
            screenThresholdLow = 0f;
            screenThresholdHigh = Screen.height/2;
        }

        iniY = transform.position.y;
        relocator = FindObjectOfType<AppleRelocator>(); 
    }
    private void Update()
    {
        if (!handReached && Input.GetMouseButtonDown(0) && Input.mousePosition.y < screenThresholdHigh && Input.mousePosition.y > screenThresholdLow)
        {
            handReached=true;
            transform.DOMoveY(finalY,0.5f).SetEase(movementEase);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Apple")
        {
            collision.transform.position = Vector3.zero;
            collision.transform.parent = transform.GetChild(1);
            transform.DOMoveY(iniY, 0.3f).SetEase(movementEase).OnComplete(() =>
            {
                handReached = false;
                if (gameObject.name == "Red")
                {
                    if (relocator.redScore < 4)
                        relocator.redScore++;
                    else
                        relocator.gameOver = true;
                }
                else
                    if (relocator.greenScore < 4)
                        relocator.greenScore++;
                    else
                        relocator.gameOver = true;
                relocator.RespwanApple();
            });
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.DOMoveY(iniY, 0.3f).SetEase(movementEase).OnComplete(() =>
        {
            handReached = false;
        });
        if (gameObject.name == "Red")
        {
            if (relocator.redScore >= -2)
                relocator.redScore--;
            else
                relocator.gameOver = true;
        }
        else
            if (relocator.greenScore >= -2)
                relocator.greenScore--;
            else
                relocator.gameOver = true;
        

    }
}
