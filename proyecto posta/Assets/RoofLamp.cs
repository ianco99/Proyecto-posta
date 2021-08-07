﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofLamp : Interactable1
{
    [SerializeField] GameObject luz;
    bool on = true;
    public override void Interact()
    {
        on = !on;
        luz.SetActive(on);
        
    }
    public override string GetDescription()
    {
        return "Apreta la " + "E" +" para apagar/prender la luz.";
    }
}
