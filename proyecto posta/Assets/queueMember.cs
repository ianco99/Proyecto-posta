﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class queueMember : Interactable1
{
    [SerializeField] bool isCorrectOne;
    [SerializeField] string correctDesc;
    [SerializeField] string descripcion;
    [SerializeField] bool used;
    private void Start()
    {
        GameEvents.current.pickedFlower += UpdateDesc;
    }
    public override void Interact()
    {
        if (!used)
        {
            if (!isCorrectOne)
            {
                Debug.Log(descripcion);

            }
            else
            {
                //GameObject.FindGameObjectWithTag("Text").GetComponent<ReadTxt>().StartDialogue("Jardin.txt", 46, 46, false);
                Debug.Log(correctDesc);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().jardinPuzzles++;
                GameEvents.current.PickedFlowers();
                GameEvents.current.ActivateSpray();
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().jardinPuzzles++;
                GameObject.FindGameObjectWithTag("Text").GetComponent<ReadTxt>().StartDialogue("Jardin.txt", 10, 18, false);
            }
        }
    }

    void UpdateDesc()
    {
        used = true;
    }
    public override void changeCamera()
    {

    }

    public override string GetDescription()
    {
        return "Apretá E para examinar las flores";
    }
}
