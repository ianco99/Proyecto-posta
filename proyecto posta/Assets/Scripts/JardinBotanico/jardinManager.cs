using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

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
        GameEvents.current.FinishedWalking += finishedWalk;
        GameEvents.current.prepareFlowers += flowersActivate;
        GameEvents.current.finishedFlowerPuzzle += lightsEnd;
    }

    private void Update()
    {
        playerStats = player.GetComponent<PlayerManager>().jardinPuzzles;
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
    void lightsEnd()
    {
        generador.tag = "Untagged";
        generador.GetComponent<Lightbulb>().enabled = false;
    }
    public void stopTimeline()
    {
        GetComponent<PlayableDirector>().Stop();
        GameObject.FindGameObjectWithTag("Text").GetComponent<ReadTxt>().StartDialogue("Jardin.txt", 38, 45, false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().jardinPuzzles++;
    }
    void stopDialogue()
    {
        switch (playerStats)
        {
            case 0: //INICIO
                gameManager.instance.UpdateGameState(GameState.Dialogue);
                kevin.GetComponent<Animator>().SetBool("fotoIdle", false);
                kevin.GetComponent<KevinMOv>().MoveToThisPoint(kevinDialogPos.position, true);
                player.GetComponent<KevinMOv>().MoveToThisPoint(finnDialogPos.position, false);
                //player.GetComponent<PlayerManager>().b = finnDialogPos.position;
                //player.GetComponent<PlayerManager>().canLerp = true;
                //Debug.Log("cambio");
                break;
            case 1: //
                //kevin.GetComponent<KevinMOv>().MoveToThisPoint(kevinInicioPos.position);
                //Debug.Log("SASASA");
                break;
            case 3:
                gameManager.instance.UpdateGameState(GameState.Dialogue);
                //player.GetComponent<scriptDeSanti>().MoveToDestination(finnFlowerPos.position);
                kevin.GetComponent<KevinMOv>().MoveToThisPoint(kevinFlowerPos.position, true);
                
                break;
            case 7:
                GetComponent<PlayableDirector>().Play();
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().jardinPuzzles++;
                break;
            case 9:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
        }
    }

    void finishedWalk()
    {
        switch (playerStats)
        {
            case 0: //INICIO
                GameObject.FindGameObjectWithTag("Text").GetComponent<ReadTxt>().StartDialogue("Jardin.txt", 3, 9, true);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().jardinPuzzles++;
                break;
            case 1: //
                kevin.GetComponent<KevinMOv>().MoveToThisPoint(kevinInicioPos.position, true);
                Debug.Log("SASASA");
                break;
            case 3:
                kevin.GetComponent<Animator>().SetBool("fotoIdle", true);
                GameObject.FindGameObjectWithTag("Text").GetComponent<ReadTxt>().StartDialogue("Jardin.txt", 18, 25, true);
                GameEvents.current.ActivateSpray();
                //GameEvents.current.PrepareFlowers();
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().jardinPuzzles++;
                break;
            default:
                break;
        }
    }
}
