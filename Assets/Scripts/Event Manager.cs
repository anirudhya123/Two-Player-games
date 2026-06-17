using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{

    [SerializeField] GameObject LandingPage;
    [SerializeField] GameObject MenuPage;
    [SerializeField] AudioManager audioManager;
    [SerializeField] AudioClip[] track;
    public void ReloadSpinner()
    {
        SceneManager.LoadScene(2);
    }

    public void ResetSpinner()
    {
        audioManager.PlayParticular(track[Random.Range(0, track.Length)]);
        GameManager.redScore = 0;
        GameManager.blueScore = 0;
        SceneManager.LoadScene(2);
    }

    public void SpinnerMenu()
    {
        GameManager.redScore = 0;
        GameManager.blueScore = 0;
        SceneManager.LoadScene(1);
    }

    public void SinglePlayer()
    {
        audioManager.PlayParticular(track[Random.Range(0, track.Length)]);
        GameManager.singlePlayer = true;
        GameManager.dualPlayer = false;
        SceneManager.LoadScene(2);
    }

    public void DoublePlayer() {
        audioManager.PlayParticular(track[Random.Range(0, track.Length)]);
        GameManager.dualPlayer=true;
        GameManager.singlePlayer=false;
        SceneManager.LoadScene(2);
    }

    public void LetItRip()
    {
        LandingPage.SetActive(false);
        MenuPage.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartApple()
    {
        SceneManager.LoadScene(3);
    }

    

    public void LoadGame(int SceneId)
    {
        SceneManager.LoadScene(SceneId);
    } 

    public void LoadGameGallery()
    {
        SceneManager.LoadScene(0);
    }
}
