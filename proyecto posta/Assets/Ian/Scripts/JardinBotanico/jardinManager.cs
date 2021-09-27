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
                gameManager.instance.UpdateGameState(GameState.Cinematic);
                kevin.GetComponent<KevinMOv>().MoveToThisPoint(new Vector3(10, 0, 20));
                break;
        }
    }
}
