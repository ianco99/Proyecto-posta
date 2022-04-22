using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class terrazaManager : MonoBehaviour
{
    int playerStats;
    GameObject player;
    ReadTxt dialogue;
    [SerializeField] GameObject council;
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
        playerStats = player.GetComponent<PlayerManager>().terrazaDialogos;
    }

    void stopDialogue()
    {
        if (playerStats == 0)
        {
            player.GetComponent<PlayerManager>().terrazaDialogos++;
            council.SetActive(true);
            dialogue.StartDialogue("terraza.txt", 29, 43, false);
        }
        if(playerStats == 1)
        {
            this.GetComponent<PlayableDirector>().Play();
            SceneManager.LoadScene("StartMenu");
        }
    }

    void stopWalking()
    {
        if (playerStats == 0)
        {
            dialogue.StartDialogue("terraza.txt", 0, 29, false);
            
        }

    }

    public void kevinScared()
    {
        //Debug.LogError("WAWWA");
        dialogue.StartDialogue("CuartoDeKevin.txt", 3, 4, true);
    }
}
