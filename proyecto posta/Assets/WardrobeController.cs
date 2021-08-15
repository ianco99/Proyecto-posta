using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeController : Interactable1
{
    [SerializeField] GameObject student;
    bool used = false;
    public override void Interact()
    {
        
        if (!used)
        {
            GetComponent<Animator>().enabled = true;
            GetComponent<BoxCollider>().enabled = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().bibliotecaPuzzles++;
            used = !used;
        }
        

        Debug.Log("Moviendo wardrobe eyyy");
    }

    public override string GetDescription()
    {
        return "Apreta la " + "E" + " para apagar/prender la luz.";
    }

    public void shooStudent()
    {
        student.gameObject.SetActive(false);
    }
}
