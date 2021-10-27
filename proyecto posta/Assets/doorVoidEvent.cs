using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class doorVoidEvent : MonoBehaviour
{
    public void eventO()
    {
        GameObject playCam = GameObject.Find("PlayCam");
        gameManager.instance.UpdateGameState(GameState.Playing);
        GameObject zz = GameObject.FindGameObjectWithTag("Player");
        playCam.GetComponent<CinemachineVirtualCamera>().Follow = zz.transform;
        playCam.GetComponent<CinemachineVirtualCamera>().LookAt = zz.transform;
    }
}
