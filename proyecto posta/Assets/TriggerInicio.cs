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
                gameManager.instance.level = 2;
                Debug.Log("Hablando con el profe y kevin");
                Debug.Log("uwu");
            }
            else if(other.transform.gameObject.GetComponent<PlayerManager>().bibliotecaPuzzles == 1)
            {
                Debug.Log("Podes pasar");
                //tiene que poner el dialogo y hacer que el jugador pueda pasar por la puerta y desactivar que el jugador pueda acceder a la luz
                other.transform.gameObject.GetComponent<PlayerManager>().bibliotecaPuzzles++;
            }
            
            //gameManager.instance.UpdateGameState(GameState.Dialogue);
            //dialogueManager.readtxt(institutodearte);
        }
    }
}
