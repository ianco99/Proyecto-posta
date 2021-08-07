using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    public GameObject Door;
    public GameObject Kevin;
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
            Debug.Log("TAX");
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
}
