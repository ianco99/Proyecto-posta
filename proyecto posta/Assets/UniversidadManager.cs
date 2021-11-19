using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;

public class UniversidadManager : MonoBehaviour
{
    int playerStats;
    GameObject player;
    ReadTxt dialogue;
    [SerializeField] GameObject kevin;
    [SerializeField] Transform kevinQueuePos;
    [SerializeField] Transform finnQueuePos;
    [SerializeField] GameObject[] sprays;
    [SerializeField] Animator ticket;
    [SerializeField] Transform ticketTransf;

    private void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().cuartoKevinDialogues;
        GameEvents.current.kevinStoppedTalking += stopDialogue;
        GameEvents.current.FinishedWalking += stopWalking;
        GameEvents.current.spraysUniversidad += spraysActivated;
        GameEvents.current.acondicionadorOn += ticketFalls;
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
            kevin.GetComponent<KevinMOv>().MoveToThisPoint(kevinQueuePos.position, false);
            player.GetComponent<KevinMOv>().MoveToThisPoint(finnQueuePos.position, true);
        }
        else if (playerStats == 2)
        {
            foreach (GameObject spray in sprays)
            {
                spray.GetComponent<Outline>().enabled = true;
            }
        }
        ///GameObject.FindGameObjectWithTag("GameController").GetComponent<timelineController>().Play();
        //Kevin.GetComponent<KevinMOv>().MoveToThisPoint(, true);
    }

    void stopWalking()
    {
        if(playerStats == 1)
        {
            dialogue.StartDialogue("universidad.txt", 1, 8, true);
        }
    }

    public void spraysActivated()
    {
        ticket.Play("New Animation");
        GameObject.Find("PlayCam").GetComponent<CinemachineVirtualCamera>().Follow = ticketTransf;
    }

    public void ticketFalls()
    {
        ticket.Play("clip1");
    }
}
