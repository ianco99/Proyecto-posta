using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerFinDialogoBotanico : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().jardinPuzzles++;
            GameObject.FindGameObjectWithTag("Text").GetComponent<ReadTxt>().StartDialogue("Jardin.txt", 3, 9, true);
            
            Destroy(gameObject);
        }
    }
}
