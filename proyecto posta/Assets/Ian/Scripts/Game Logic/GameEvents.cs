using System;
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

    public event Action FinishedWalking;

    public void FinishedWalkingToPoint()
    {
        if(FinishedWalking != null)
        {
            FinishedWalking();
        }
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

    public event Action activatingSpray;
    public void ActivateSpray()
    {
        if (activatingSpray != null)
        {
            activatingSpray();
        }
    }

    public event Action pickingFlowers;
    public void ActivateFlowers()
    {
        if (activatingSpray != null)
        {
            pickingFlowers();
        }
    }

    public event Action pickedFlower;
    public void PickedFlowers()
    {
        if(pickedFlower != null)
        {
            pickedFlower();
        }
    }

    public event Action prepareFlowers;
    public void PrepareFlowers()
    {
        if (prepareFlowers != null)
        {
            prepareFlowers();
        }
    }

    public event Action finishedFlowerPuzzle;
    public void FinishedFlowerPuzzle()
    {
        if (finishedFlowerPuzzle != null)
        {
            finishedFlowerPuzzle();
        }
    }

    public event Action talkedToRightQueue;
    public void TalkedToRightQueue()
    {
        if(talkedToRightQueue != null)
        {
            talkedToRightQueue();
        }
    }
    public event Action spraysUniversidad;
    public void SpraysUniversidad()
    {
        if (spraysUniversidad != null)
        {
            spraysUniversidad();
        }
    }
}
