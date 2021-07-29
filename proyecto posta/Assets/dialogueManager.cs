using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class dialogueManager : MonoBehaviour
{
    public GameObject dialogoCanvas;
    public float startHoldTime;
    float holdTime;
    public GameObject player;
    public GameObject HUD;

    public static dialogueManager current;

    public event Action TalkedToKevin;
    private void Awake()
    {
        current = this;
        HUD.SetActive(false);
        player.GetComponent<Movement>().enabled = false;
        player.GetComponent<Possess>().enabled = false;
        player.GetComponent<PushNPull>().enabled = false;
        player.GetComponentInChildren<Interactions>().enabled = false;
        TalkedToKevin();
    }
    private void Update()
    {
        dialogoCanvas.SetActive(holdTime < startHoldTime);
        holdTime += Time.deltaTime;

        if(dialogoCanvas.gameObject.activeSelf == false)
        {
            HUD.SetActive(true);
            player.GetComponent<Movement>().enabled = true;
            player.GetComponent<Possess>().enabled = true;
            player.GetComponent<PushNPull>().enabled = true;
            player.GetComponentInChildren<Interactions>().enabled = true;
            gameManager.instance.UpdateGameState(GameState.Playing);
        } 
    }
}
