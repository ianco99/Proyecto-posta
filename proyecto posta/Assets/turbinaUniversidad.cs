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
        particle.SetActive(true);
        GameEvents.current.AcondicionadorOn();
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
        if (!used)
        {
            playCam = GameObject.Find("PlayCam");
            ActivateSpray();
            gameManager.instance.UpdateGameState(GameState.Cinematic);
            changeCamera();
            used = !used;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().universidadPuzzles++;

        }
    }
}
