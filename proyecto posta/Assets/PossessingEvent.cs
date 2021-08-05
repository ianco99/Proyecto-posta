using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessingEvent : MonoBehaviour
{
    public GameObject player;
    public bool finished;
    void PossesEvent()
    {
        player.GetComponent<Possess>().Possesing();
        //finished = true;
    }
    void BackToNormalEvent()
    {
        player.GetComponent<Possess>().goBackToNormal();
    }
}
