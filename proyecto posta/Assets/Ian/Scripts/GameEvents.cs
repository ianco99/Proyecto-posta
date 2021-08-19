﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    private void Awake()
    {
        current = this;
       // dialogueManager.current.TalkedToKevin += DoorFuctions;
    }

    public event Action TalkedToKevin;
    public void TalkedToKevinFunct()
    {
        Debug.Log("Sumbini");
        if(TalkedToKevin != null)
        {
            TalkedToKevin();
        }
    }

    public event Action StudentScared;

    public void ScaringStudent()
    {
        Debug.Log("Scaring");
        if(StudentScared != null)
        {
            StudentScared();
        }
    }

    public event Action kevinArtSupplies;

    public void KevinArtSupplies()
    {
        if(kevinArtSupplies != null)
        {
            kevinArtSupplies();
        }
    }

    public event Action needScaring;

    public void KevinNeedsScaring()
    {
        if(needScaring != null)
        {
            needScaring();
        }
    }

    public event Action kevinStoppedTalking;

    public void StoppedTalking()
    {
        if (kevinStoppedTalking != null)
        {
            kevinStoppedTalking();
        }
    }
}
