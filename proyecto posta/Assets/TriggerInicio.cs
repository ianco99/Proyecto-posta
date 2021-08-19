using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInicio : MonoBehaviour
{
    public Transform proxPosKevin;
    public Transform kevin;
    public GameObject dialogueManager;
    ReadTxt script;
    bool on = true;
    public scriptDeSanti mover;

    private void Start()
    {
        GameEvents.current.kevinStoppedTalking += moveKevin;
    }
    private void OnTriggerEnter(Collider other)
    {
        script = dialogueManager.GetComponent<ReadTxt>();
        if (other.tag == "Player")
        {
            if(other.transform.gameObject.GetComponent<PlayerManager>().bibliotecaPuzzles == 0 && on)
            {
                gameManager.instance.level = 2;
                script.StartDialogue("InstitutoArte.txt", 0, 6);
                Debug.Log("Hablando con el profe y kevin");
                Debug.Log("uwu");
                on = false;
            }
            else if(other.transform.gameObject.GetComponent<PlayerManager>().bibliotecaPuzzles == 1 && !on)
            {
                Debug.Log("Podes pasar");
                script.StartDialogue("InstitutoArte.txt", 9, 13);
                on = !on;
                //tiene que poner el dialogo y hacer que el jugador pueda pasar por la puerta y desactivar que el jugador pueda acceder a la luz
                
            }
            //gameManager.instance.UpdateGameState(GameState.Dialogue);
            //dialogueManager.readtxt(institutodearte);
        }
    }

    void moveKevin()
    {
        if (on)
        {
            on = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().bibliotecaPuzzles++;
            Debug.Log("Asheee");
            mover.MoveToDestination(proxPosKevin.position);
            //kevin.position = proxPosKevin.position;
        }
        
    }
}
