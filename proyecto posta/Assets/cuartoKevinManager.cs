using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

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
    [SerializeField] Transform cameraPosPuerta1;
    [SerializeField] Transform bookFinn;
    [SerializeField] Transform cameraPosCama;

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
            playCam.GetComponent<CinemachineVirtualCamera>().Follow = cameraPosPuerta1.transform;
            dialogue.StartDialogue("CuartoDeKevin.txt", 13,17,false);
            player.GetComponent<PlayerManager>().cuartoKevinDialogues++;
        }
        else if (playerStats == 3)
        {
            council.SetActive(false);
            GameObject playCam = GameObject.Find("PlayCam");
            playCam.GetComponent<CinemachineVirtualCamera>().Follow = cameraPosKevinFinn.transform;
            dialogue.StartDialogue("CuartoDeKevin.txt", 18, 33, false);
            player.GetComponent<PlayerManager>().cuartoKevinDialogues++;
        }
        else if (playerStats == 4)
        {
            player.GetComponent<KevinMOv>().MoveToThisPoint(bookFinn.position, true);
        }
        else if (playerStats == 5)
        {
            GameObject playCam = GameObject.Find("PlayCam");
            playCam.GetComponent<CinemachineVirtualCamera>().Follow = cameraPosCama.transform;
            dialogue.StartDialogue("CuartoDeKevin.txt", 47, 49, false);
            player.GetComponent<PlayerManager>().cuartoKevinDialogues++;
        }
        else if (playerStats == 6)
        {
            GameObject playCam = GameObject.Find("PlayCam");
            playCam.GetComponent<CinemachineVirtualCamera>().Follow = cameraPosKevinFinn.transform;
            player.GetComponent<PlayerManager>().cuartoKevinDialogues++;
            dialogue.StartDialogue("CuartoDeKevin.txt", 50, 63, false);
        }
        else if (playerStats == 7)
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
            gameManager.instance.UpdateGameState(GameState.Dialogue);
            player.GetComponent<KevinMOv>().enabled = false;
            dialogue.StartDialogue("CuartoDeKevin.txt", 0, 2, false);
            door.GetComponent<cuartoDeKevinDoor>().changePos();
        }
        else if(playerStats == 2)
        {
            dialogue.StartDialogue("CuartoDeKevin.txt", 3, 12, false);
        }
        else if(playerStats == 4)
        {
            dialogue.StartDialogue("CuartoDeKevin.txt", 34, 45, false);
            player.GetComponent<PlayerManager>().cuartoKevinDialogues++;
        }
        
    }

    public void kevinScared()
    {
        //Debug.LogError("WAWWA");
        dialogue.StartDialogue("CuartoDeKevin.txt", 3, 4, true);
    }
}
