using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class turbinaUniversidad : Interactable1
{
    [SerializeField] GameObject particle;
    bool used = false;
    [SerializeField] string descripcion;
    [SerializeField] float cameraTime;
    [SerializeField] float holdCameraTime;
    GameObject playCam;
    private void ActivateSpray()
    {
        particle.GetComponent<ParticleSystem>().Play();
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().universidadPuzzles == 4)
        {
            
            GameEvents.current.AcondicionadorOn();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().universidadPuzzles++;
        }
    }
    public override string GetDescription()
    {

        return "sas" + descripcion;
    }

    public override void changeCamera()
    {

        GameObject playCam = GameObject.Find("PlayCam");
        playCam.GetComponent<CinemachineVirtualCamera>().Follow = cameraPos;
    }
    public override void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            playCam = GameObject.Find("PlayCam");
            ActivateSpray();
            changeCamera();
            used = !used;
            
        }

    }
}
