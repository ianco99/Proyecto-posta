﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofLamp : Interactable1
{
    [SerializeField] GameObject luz;
    bool on = true;
    GameObject player;

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
            GameEvents.current.ScaringStudent();
        }
    }
    public override string GetDescription()
    {
        return "Apreta la " + "E" +" para apagar/prender la luz.";
    }
}
