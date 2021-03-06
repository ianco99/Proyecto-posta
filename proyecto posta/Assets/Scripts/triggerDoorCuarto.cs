using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDoorCuarto : MonoBehaviour
{
    [SerializeField] GameObject puerta;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gameManager.instance.UpdateGameState(GameState.Dialogue);
            GameObject.FindGameObjectWithTag("Player").GetComponent<KevinMOv>().enabled = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().cuartoKevinDialogues++;
            GameObject.FindGameObjectWithTag("Text").GetComponent<ReadTxt>().StartDialogue("CuartoDeKevin.txt", 0, 2, true);
            puerta.GetComponent<cuartoDeKevinDoor>().changePos();
            Destroy(gameObject);
        }
    }
}
