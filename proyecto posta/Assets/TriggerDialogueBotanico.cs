using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogueBotanico : MonoBehaviour
{
    GameObject Kevin;
    bool used = false;

    private void Start()
    {
        Kevin = GameObject.Find("KEVIN");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!used)
        {
            if (other.tag == "Player")
            {
                GameObject.FindGameObjectWithTag("Text").GetComponent<ReadTxt>().StartDialogue("Jardin.txt", 0, 2, false);
                
                //Kevin.GetComponent<KevinMOv>().StartDialogueEsp();
                used = !used;
            }
        }
        
    }
}
