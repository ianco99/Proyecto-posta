using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInicio : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(other.transform.gameObject.GetComponent<PlayerManager>().bibliotecaPuzzles == 0)
            {
                Debug.Log("Hablando con el profe y kevin");
                Debug.Log("uwu");
            }
            else if(other.transform.gameObject.GetComponent<PlayerManager>().bibliotecaPuzzles == 1)
            {
                Debug.Log("Podes pasar");
            }
            
            //gameManager.instance.UpdateGameState(GameState.Dialogue);
            //dialogueManager.readtxt(institutodearte);
        }
    }
}
