using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RoofLamp : Interactable1
{
    [SerializeField] GameObject luz;
    bool on = true;
    GameObject player;
    [SerializeField] GameObject student;
    [SerializeField] Transform runToPosition;
    [SerializeField] GameObject panel;
    [SerializeField] Animation fade, titilar;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public override void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //on = !on;
            //luz.SetActive(on);
            panel.SetActive(true);
            if (player.GetComponent<PlayerManager>().bibliotecaPuzzles == 0)
            {
                player.GetComponent<PlayerManager>().bibliotecaPuzzles++;
                gameManager.instance.UpdateGameState(GameState.Cinematic);
                Destroy(student);
                //student.GetComponent<KevinMOv>().MoveToThisPoint(runToPosition.position, false);
                panel.SetActive(true);
                GameEvents.current.ScaringStudent();
            }
        }
        
    }

    public override void changeCamera()
    {
        GameObject playCam = GameObject.Find("PlayCam");
        playCam.GetComponent<CinemachineVirtualCamera>().Follow = cameraPos;
        playCam.GetComponent<CinemachineVirtualCamera>().LookAt = cameraPos;
    }

    public override string GetDescription()
    {
        return "Apreta la E para apagar/prender la luz y la F para salir del objeto.";
    }
}
