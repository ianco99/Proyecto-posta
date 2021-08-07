using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    public GameObject dialogueManager;

    public GameObject player;

    public GameObject HUD;

    public int level = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //GameEvents.current.pauseMenu += OnPause;
        //GameEvents.current.resumePlay += ResumePlay;

    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.Menu:
                HandleMenu();
                break;
            case GameState.Playing:
                HandlePlaying();
                break;
            case GameState.Pause:
                break;
            case GameState.Dialogue:
                HandleDialogue();
                break;
            case GameState.Cinematic:
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    private void HandleDialogue()
    {
        HUD.SetActive(false);
        player.GetComponent<Movement>().enabled = false;
        player.GetComponent<Possess>().enabled = false;
        player.GetComponent<PushNPull>().enabled = false;
        player.GetComponentInChildren<Interactions>().enabled = false;
    }
    private void HandlePlaying()
    {
        HUD.SetActive(true);
        player.GetComponent<Movement>().enabled = true;
        player.GetComponent<Possess>().enabled = true;
        player.GetComponent<PushNPull>().enabled = true;
        player.GetComponentInChildren<Interactions>().enabled = true;
    }
    //private void OnPuzzleSolved()
    //{
    //    //spark.gameObject.SetActive(true);
    //}

    //private void OnPuzzleUnsolved()
    //{
    //    //    spark.gameObject.SetActive(false);
    //}
}

public enum GameState
{
    Menu,
    Playing,
    Pause,
    Dialogue,
    Cinematic

}
