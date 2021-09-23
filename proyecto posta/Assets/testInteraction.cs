using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testInteraction : Interactable1
{
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("SASSASA");
                Interact();
            }
        }
        
    }

    public override void Interact()
    {
        Debug.Log("Interacted");
    }

    public override string GetDescription()
    {
        return "Apagame asheee";
    }

    public override void changeCamera()
    {
        throw new System.NotImplementedException();
    }

}
