using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class UniversidadManager : MonoBehaviour
{
    int playerStats;
    GameObject player;
    ReadTxt dialogue;

    private void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().cuartoKevinDialogues;
        GameEvents.current.kevinStoppedTalking += stopDialogue;
        GameEvents.current.FinishedWalking += stopWalking;
        
        player = GameObject.FindGameObjectWithTag("Player");
        dialogue = GameObject.FindGameObjectWithTag("Text").GetComponent<ReadTxt>();
    }
    private void Update()
    {
        playerStats = player.GetComponent<PlayerManager>().universidadPuzzles;
    }

    void stopDialogue()
    {
        if (playerStats == 0)
        {
            player.GetComponent<PlayerManager>().universidadPuzzles++;
            Debug.Log("Mira la fila qcy");
        }
        else if (playerStats == 2)
        {
           
        }
        ///GameObject.FindGameObjectWithTag("GameController").GetComponent<timelineController>().Play();
        //Kevin.GetComponent<KevinMOv>().MoveToThisPoint(, true);
    }

    void stopWalking()
    {
        gameManager.instance.UpdateGameState(GameState.Dialogue);
        player.GetComponent<KevinMOv>().enabled = false;
        player.GetComponent<PlayerManager>().cuartoKevinDialogues++;
        dialogue.StartDialogue("CuartoDeKevin.txt", 0, 2, false);
    }

    public void kevinScared()
    {
        //Debug.LogError("WAWWA");
        dialogue.StartDialogue("CuartoDeKevin.txt", 3, 4, true);
    }
}
