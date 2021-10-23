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
            if (other.GetComponent<PlayerManager>().jardinPuzzles == 0)
            {
                Debug.Log("Finn, elijamos la flor correcta!");
                //GameEvents.current.ActivateFlowers();
                player.GetComponent<PlayerManager>().jardinPuzzles++;
            }
            else if (other.GetComponent<PlayerManager>().jardinPuzzles == 2)
            {
                other.GetComponent<PlayerManager>().jardinPuzzles++;
                GameEvents.current.ActivateSpray();
                Debug.Log("Finn, podes prender el agua?");
            }
            else if(other.GetComponent<PlayerManager>().jardinPuzzles == 4)
            {
                other.GetComponent<PlayerManager>().jardinPuzzles++;
                Debug.Log("Finn, podes apagar las otras luces?");
            }
        }
    }
}
