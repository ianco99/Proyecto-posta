using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spotMonologo : MonoBehaviour
{
    public int id;
    public ReadTxt script;
    public bool[] ids = {true, true, true};
    public GameObject dialogueManager;

    void Awake(){
        dialogueManager = GameObject.Find("Dialogue Manager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            script = dialogueManager.GetComponent<ReadTxt>();
            if(id == 1 && ids[0] && this.name == "Spot Monologo 1"){
                Debug.Log("Aca");
                script.StartDialogue("Bosque.txt.txt", 0, 6, true);
                StartCoroutine(script.waitTen());
                ids[0] = false;
            }
            if(id == 2 && ids[1]){
                Debug.Log("2");
                script.NextDialogue(0);
                script.cambiaDialogo = true;
                script.setEstaPresente(true);
                StartCoroutine(script.waitTen());
                ids[1] = false;
            }
            if(id == 3 && ids[2]){
                Debug.Log("3");
                script.NextDialogue(1);
                script.cambiaDialogo = true;
                script.setEstaPresente(true);
                StartCoroutine(script.waitTen());
                ids[2] = false;
            }
        }
    }
}
