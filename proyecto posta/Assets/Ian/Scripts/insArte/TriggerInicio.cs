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
                
                on = false;
            }
            else if (other.transform.gameObject.GetComponent<PlayerManager>().bibliotecaPuzzles == 1 && !on)
            {
                script.StartDialogue("InstitutoArte.txt", 9, 13, true);
                on = !on;

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
            StartCoroutine(mover.points(new Vector3[] { proxPosKevin.position, pos2.position }));
            profe.GetComponent<scriptDeSanti>().MoveToDestination(direccionProfe.position);
            //santi.MoveToDestination(direccionProfe.position);
            profe.GetComponent<Animator>().SetBool("MovingX", true);
            profe.GetComponent<Animator>().SetBool("Idle", false);
            //StartCoroutine("DAAALE");
            //kevin.position = proxPosKevin.position;
        }

    }

    //IEnumerator DAAALE()
    //{
    //     yield return new WaitForSeconds(3);
    //    profe.GetComponent<Animator>().SetBool("Idle", true);
    //    profe.GetComponent<Animator>().SetBool("MovingX", false);
    //}
}
