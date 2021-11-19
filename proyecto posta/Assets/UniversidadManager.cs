using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
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
    [SerializeField] Transform kevinTicket;
    [SerializeField] GameObject council;

    private void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().cuartoKevinDialogues;
        GameEvents.current.kevinStoppedTalking += stopDialogue;
        GameEvents.current.FinishedWalking += stopWalking;
        GameEvents.current.spraysUniversidad += spraysActivated;
        GameEvents.current.acondicionadorOn += ticketFalls;
        GameEvents.current.ticketFell += ticketGround;
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
        else if (playerStats == 4)
        {
            kevin.GetComponent<KevinMOv>().MoveToThisPoint(Vector3.zero, false);
            player.GetComponent<PlayerManager>().universidadPuzzles++;
            council.SetActive(true);
            dialogue.StartDialogue("universidad.txt", 24, 26, false);
            

        }
        else if (playerStats == 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


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
        else if(playerStats == 3)
        {
            dialogue.StartDialogue("universidad.txt", 20, 24, false);
            player.GetComponent<PlayerManager>().universidadPuzzles++;
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
        GameObject.Find("PlayCam").GetComponent<CinemachineVirtualCamera>().Follow = ticketTransf;
    }

    public void ticketGround()
    {
        kevin.GetComponent<KevinMOv>().MoveToThisPoint(kevinTicket.position, true);
    }
}
