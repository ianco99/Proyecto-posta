using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerInicioBotanico : MonoBehaviour
{
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(other.GetComponent<PlayerManager>().jardinPuzzles == 0)
            {
                other.GetComponent<PlayerManager>().jardinPuzzles++;
                GameEvents.current.ActivateSpray();
            }
            else if(other.GetComponent<PlayerManager>().jardinPuzzles == 2)
            {
                other.GetComponent<PlayerManager>().jardinPuzzles++;
            }
        }
    }
}
