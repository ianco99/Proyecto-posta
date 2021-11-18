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
    [SerializeField]float cameraTime;
    [SerializeField] float holdCameraTime;
    GameObject playCam;
    private void ActivateSpray()
    {

        foreach (GameObject spray in Particles)
        {
            spray.SetActive(true);
        }
        
    }

    private void Update()
    {
        if (on)
        {
            cameraTime += Time.deltaTime;
            if (holdCameraTime < cameraTime)
            {
                playCam.GetComponent<CinemachineVirtualCamera>().Follow = GameObject.FindGameObjectWithTag("Player").transform;
                cameraTime = 0;
                on = false;
                gameManager.instance.UpdateGameState(GameState.Playing);
            }
        }
    }
    public override string GetDescription()
    {
        
        return descripcion;
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
            on = true;
            changeCamera();
            //HACE QUE EL CAMBIO DE CAMARA SEA POR UNOS SEGUNDOS
            Debug.Log("fire");
            used = !used;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().jardinPuzzles++;
            
        }
    }

}
