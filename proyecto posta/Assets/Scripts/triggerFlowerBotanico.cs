using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerFlowerBotanico : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && other.GetComponent<PlayerManager>().jardinPuzzles == 2)
        {
            GameObject.FindGameObjectWithTag("Text").GetComponent<ReadTxt>().StartDialogue("Jardin.txt", 18, 25, true);
            //GameEvents.current.ActivateSpray();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().jardinPuzzles++;
        }
    }
}
