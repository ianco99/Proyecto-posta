using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerUniversidadInicio : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Text").GetComponent<ReadTxt>().StartDialogue("universidad.txt", 0, 1, false);
            Destroy(gameObject);
        }
    }
}
