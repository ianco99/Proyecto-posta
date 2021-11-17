using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class sprayUniversidad : Interactable1
{
    public GameObject[] sprays;
    public bool isOn = true;
    public bool inverter = false;
    //hola soy blastermanmnmnmnmnmmm

    void ActivateSprays()
    {
        if (!isOn)
        {
            foreach (GameObject spray in sprays)
            {

                spray.SetActive(true);
            }
        }
        GameEvents.current.SpraysUniversidad();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().universidadPuzzles++;
    }

    public override string GetDescription()
    {
        if (isOn) return "Press [1], [2] or [3] to change the lights";
        return "Press [E] to turn <color=green>on</color> the light.";
    }

    public override void changeCamera()
    {
        GameObject playCam = GameObject.Find("PlayCam");
        playCam.GetComponent<CinemachineVirtualCamera>().Follow = cameraPos;
        playCam.GetComponent<CinemachineVirtualCamera>().LookAt = cameraPos; ;
    }
    public override void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ActivateSprays();
        }
    }
}
