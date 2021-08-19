using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofLamp : Interactable1
{
    [SerializeField] GameObject luz;
    bool on = true;
    GameObject player;
    [SerializeField] GameObject student;
    [SerializeField] Transform runToPosition;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public override void Interact()
    {
        on = !on;
        luz.SetActive(on);
        if(player.GetComponent<PlayerManager>().bibliotecaPuzzles == 0)
        {
            player.GetComponent<PlayerManager>().bibliotecaPuzzles++;
            student.GetComponent<scriptDeSanti>().MoveToDestination(runToPosition.position);
            GameEvents.current.ScaringStudent();
        }
    }
    public override string GetDescription()
    {
        return "Apreta la E para apagar/prender la luz y la F para salir del objeto.";
    }
}
