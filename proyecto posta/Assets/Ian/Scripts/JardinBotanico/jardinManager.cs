using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jardinManager : MonoBehaviour
{
    [SerializeField] Transform finnDialogPos;
    [SerializeField] Transform kevinDialogPos;
    [SerializeField] Transform kevinInicioPos;
    [SerializeField] GameObject generador;
    [SerializeField] GameObject sprayerController;
    [SerializeField] GameObject[] flowers;
    [SerializeField] Transform finnFlowerPos;
    [SerializeField] Transform kevinFlowerPos;
    int playerStats;
    GameObject player;
    GameObject kevin;

    // Start is called before the first frame update
    void Start()
    {
        kevin = GameObject.Find("KEVIN");
        player = GameObject.FindGameObjectWithTag("Player");
        
        GameEvents.current.activatingSpray += sprayActivate;
        GameEvents.current.pickingFlowers += flowersActivate;
        GameEvents.current.kevinStoppedTalking += stopDialogue;
    }

    private void Update()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().jardinPuzzles;
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
                kevin.GetComponent<KevinMOv>().MoveToThisPoint(kevinDialogPos.position);
                player.GetComponent<KevinMOv>().MoveToThisPoint(finnDialogPos.position);
                Debug.Log("cambio");
                break;
            case 1:
                kevin.GetComponent<KevinMOv>().MoveToThisPoint(kevinInicioPos.position);
                Debug.Log("SASASA");
                break;
            case 2:
                player.GetComponent<KevinMOv>().MoveToThisPoint(finnFlowerPos.localPosition);
                kevin.GetComponent<KevinMOv>().MoveToThisPoint(kevinFlowerPos.position);
                
                break;
        }
    }
}
