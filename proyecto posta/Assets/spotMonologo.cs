using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spotMonologo : MonoBehaviour
{
    public int id;
    public GameObject dialogueManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //dialogueManager.GetComponent<ReadTxt>().StartDialogue("MonologoBosque.txt", 1,2);
        }
    }
}
