using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TriggerInicio : MonoBehaviour
{
    public Transform proxPosKevin;
    public Transform kevin;
    public Transform pos2;
    public GameObject dialogueManager;
    ReadTxt script;
    bool on = true;
    public KevinMOv mover;
    public scriptDeSanti santi;
    public Transform direccionProfe;
    public GameObject profe;
    private void Start()
    {
        GameEvents.current.kevinStoppedTalking += moveKevin;
    }
    private void OnTriggerEnter(Collider other)
    {
        script = dialogueManager.GetComponent<ReadTxt>();
        if (other.tag == "Player")
        {
            if (other.transform.gameObject.GetComponent<PlayerManager>().bibliotecaPuzzles == 0 && on)
            {
                gameManager.instance.level = 2;
                script.StartDialogue("InstitutoArte.txt", 0, 6);
                Debug.Log("Hablando con el profe y kevin");
                Debug.Log("uwu");
                on = false;
            }
            else if (other.transform.gameObject.GetComponent<PlayerManager>().bibliotecaPuzzles == 1 && !on)
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

            StartCoroutine(mover.points(new Vector3[] { proxPosKevin.position, pos2.position }));
            santi.MoveToDestination(direccionProfe.position);
            profe.GetComponent<Animator>().SetBool("MovingX", true);
            profe.GetComponent<Animator>().SetBool("Idle", false);
            StartCoroutine("DAAALE");
            //kevin.position = proxPosKevin.position;
        }

    }

    IEnumerator DAAALE()
    {
         yield return new WaitForSeconds(3);
        profe.GetComponent<Animator>().SetBool("Idle", true);
        profe.GetComponent<Animator>().SetBool("MovingX", false);
    }
}
