using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuartoKevinManager : MonoBehaviour
{
    int playerStats;
    GameObject player;

    private void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().cuartoKevinDialogues;
        GameEvents.current.kevinStoppedTalking += stopDialogue;
    }
    private void Update()
    {
        playerStats = player.GetComponent<PlayerManager>().jardinPuzzles;
    }

    void stopDialogue()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<timelineController>().Play();
    }
}
