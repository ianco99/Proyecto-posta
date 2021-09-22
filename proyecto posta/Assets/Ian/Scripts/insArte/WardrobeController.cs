using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WardrobeController : Interactable1
{
    [SerializeField] GameObject student;
    bool used = false;
    [SerializeField] Transform runToPosition;
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public override void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!used)
            {
                GetComponent<Animator>().enabled = true;
                GetComponent<BoxCollider>().enabled = false;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().bibliotecaPuzzles++;
                //Cinematica para el objeto (cambias el gamestate y no se man cambias la camara)
                used = !used;
            }
        }
    }

    public override void changeCamera()
    {
        GameObject playCam = GameObject.Find("PlayCam");
        playCam.GetComponent<CinemachineVirtualCamera>().Follow = cameraPos;
        playCam.GetComponent<CinemachineVirtualCamera>().LookAt = player.transform;
    }
    public override string GetDescription()
    {
        return "Apreta la " + "E" + " para poseer el armario.";
    }

    public void shooStudent()
    {
        student.GetComponent<scriptDeSanti>().MoveToDestination(runToPosition.position);
    }
}
