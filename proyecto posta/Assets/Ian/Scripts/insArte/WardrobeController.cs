using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeController : Interactable1
{
    [SerializeField] GameObject student;
    bool used = false;
    [SerializeField] Transform runToPosition;
    public override void Interact()
    {
        
        if (!used)
        {
            GetComponent<Animator>().enabled = true;
            GetComponent<BoxCollider>().enabled = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().bibliotecaPuzzles++;
            //Cinematica para el objeto (cambias el gamestate y no se man cambias la camara)
            used = !used;
        }
        

        Debug.Log("Moviendo wardrobe eyyy");
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
