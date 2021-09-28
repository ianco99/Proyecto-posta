using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jardinManager : MonoBehaviour
{
    [SerializeField] GameObject generador;
    [SerializeField] GameObject sprayerController;
    [SerializeField] GameObject[] flowers;
    int playerStats;
    GameObject player;
    GameObject kevin;

    // Start is called before the first frame update
    void Start()
    {
        kevin = GameObject.Find("KEVIN");
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().jardinPuzzles;
        GameEvents.current.activatingSpray += sprayActivate;
        GameEvents.current.pickingFlowers += flowersActivate;
        GameEvents.current.kevinStoppedTalking += stopDialogue;
    }

    void sprayActivate()
    {
        sprayerController.tag = "Interactable";
    }

    void flowersActivate()
    {
        foreach (GameObject flower in flowers)
        {
            flower.tag = "Interactable";
        }
    }

    void stopDialogue()
    {
        switch (playerStats)
        {
            case 0:
                gameManager.instance.UpdateGameState(GameState.Dialogue);
                kevin.GetComponent<KevinMOv>().MoveToThisPoint(new Vector3(-12.78f, 2.25f, -9.15f));
                player.GetComponent<KevinMOv>().MoveToThisPoint(new Vector3(-12f, 2.25f, -10.15f));
                break;
        }
    }
}
