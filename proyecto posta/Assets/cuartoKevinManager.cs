using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cuartoKevinManager : MonoBehaviour
{
    int playerStats;
    GameObject player;
    [SerializeField] GameObject door;
    [SerializeField] GameObject Kevin;
    [SerializeField] GameObject council;
    [SerializeField] Transform middleFinn;
    ReadTxt dialogue;
    [SerializeField] Transform cameraPosKevinFinn;

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
        playerStats = player.GetComponent<PlayerManager>().cuartoKevinDialogues;
    }

    void stopDialogue()
    {
        if(playerStats == 1)
        {
            //GameObject playCam = GameObject.Find("PlayCam");
            //playCam.GetComponent<CinemachineVirtualCamera>().Follow = player.transform;
            player.GetComponent<KevinMOv>().MoveToThisPoint(middleFinn.position, true);
            player.GetComponent<PlayerManager>().cuartoKevinDialogues++;
            GameObject playCam = GameObject.Find("PlayCam");
            playCam.GetComponent<CinemachineVirtualCamera>().Follow = cameraPosKevinFinn.transform;
            Debug.Log("Moviendose");
        }
        else if(playerStats == 2)
        {
            council.SetActive(true);
            GameObject playCam = GameObject.Find("PlayCam");
            playCam.GetComponent<CinemachineVirtualCamera>().Follow = council.transform;
            dialogue.StartDialogue("CuartoDeKevin.txt", 13,17,false);
        }
        ///GameObject.FindGameObjectWithTag("GameController").GetComponent<timelineController>().Play();
        //Kevin.GetComponent<KevinMOv>().MoveToThisPoint(, true);
    }

    void stopWalking()
    {
        if(playerStats == 1)
        {
            gameManager.instance.UpdateGameState(GameState.Dialogue);
            player.GetComponent<KevinMOv>().enabled = false;
            dialogue.StartDialogue("CuartoDeKevin.txt", 0, 2, false);
            door.GetComponent<cuartoDeKevinDoor>().changePos();
        }
        else if(playerStats == 2)
        {
            dialogue.StartDialogue("CuartoDeKevin.txt", 3, 12, false);
        }
        
    }

    public void kevinScared()
    {
        //Debug.LogError("WAWWA");
        dialogue.StartDialogue("CuartoDeKevin.txt", 3, 4, true);
    }
}
