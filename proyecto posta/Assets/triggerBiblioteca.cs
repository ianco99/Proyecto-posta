using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerBiblioteca : MonoBehaviour
{
    public ReadTxt script;
    public GameObject dialogueManager;
    bool used;
    void Awake()
    {
        dialogueManager = GameObject.Find("Dialogue Manager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("ASHEEEE");
            gameManager.instance.level = 1;
            script.StartDialogue("Biblioteca.txt", 0, 1);
            Destroy(this.gameObject);

        }
    }
}
