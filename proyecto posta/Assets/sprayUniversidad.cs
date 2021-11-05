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

    private void Update()
    {
        //if (!light1.activeSelf && light2.activeSelf && !light3.activeSelf && !light4.activeSelf)
        //{
        //    GameEvents.current.FinishedFlowerPuzzle();
        //    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().jardinPuzzles++;
        //}
    }
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
        //light1.SetActive(!light1.activeSelf);
        //light2.SetActive(!light2.activeSelf);
    }
    //void UpdateLight2()
    //{
    //    light2.SetActive(!light2.activeSelf);
    //    light4.SetActive(!light4.activeSelf);
    //}
    //void UpdateLight3()
    //{
    //    light2.SetActive(!light2.activeSelf);
    //    light3.SetActive(!light3.activeSelf);
    //    light4.SetActive(!light4.activeSelf);
    //}

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
        //else if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    UpdateLight2();
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    UpdateLight3();
        //}

    }
}
