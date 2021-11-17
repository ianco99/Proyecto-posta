using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerInicioTerraza : MonoBehaviour
{
    [SerializeField] KevinMOv player;
    [SerializeField] KevinMOv kevin;
    [SerializeField] Transform playerPos;
    [SerializeField] Transform kevinPos;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player.MoveToThisPoint(playerPos.position, false);
            kevin.MoveToThisPoint(kevinPos.position, true);
        }
    }
}
