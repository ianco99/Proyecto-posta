using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SprayManager : Interactable1
{
    [SerializeField] GameObject[] Particles;
    bool used = false;
    bool on = false;
    [SerializeField] string descripcion;
    private void ActivateSpray()
    {

        foreach (GameObject spray in Particles)
        {
            spray.SetActive(true);
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
        if (!used)
        {
            ActivateSpray();
            gameManager.instance.UpdateGameState(GameState.Cinematic);
            //HACE QUE EL CAMBIO DE CAMARA SEA POR UNOS SEGUNDOS
            Debug.Log("fire");
            used = !used;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().jardinPuzzles++;
            changeCamera();
        }
    }

}
