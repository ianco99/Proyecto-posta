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
                Kevin.GetComponent<Dialogue>().Talk("Jardin.txt", 1, 3);
                used = !used;
            }
        }
        
    }
}
