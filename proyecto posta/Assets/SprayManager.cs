using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayManager : Interactable1
{
    [SerializeField] GameObject[] Particles;
    bool used = false;
    bool on = false;
    [SerializeField] string descripcion;
    //public override void Interact()
    //{
    //    Debug.Log("sas");

    //    if (!used)
    //    {
    //        Debug.Log("ses");
    //        on = !on;
    //        ActivateSpray();
    //        used = !used;
    //    }

    //}

    //public override string GetDescription()
    //{
    //    return "Apreta la " + "E" + " para dibujar en la pizarra.";
    //}

    //public override void changeCamera()
    //{
    //    throw new System.NotImplementedException();
    //}

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

    }
    public override void Interact()
    {
        if (!used)
        {
            ActivateSpray();
            used = !used;
        }
    }

}
