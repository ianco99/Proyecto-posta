using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayManager : Interactable1
{
    [SerializeField] GameObject Particle1, Particle2;
    bool used = false;
    bool on = false;
    public override void Interact()
    {

        if (!used)
        {
            on = !on;
            ActivateSpray();
            used = !used;
        }

    }

    public override string GetDescription()
    {
        return "Apreta la " + "E" + " para dibujar en la pizarra.";
    }

    public override void changeCamera()
    {
        throw new System.NotImplementedException();
    }

    private void ActivateSpray()
    {
        Particle1.SetActive(true);
        Particle2.SetActive(true);
    }
}
