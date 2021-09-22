﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Debug.Log("uwuwuw");
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
