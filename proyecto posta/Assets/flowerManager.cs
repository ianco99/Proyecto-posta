using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerManager : Interactable1
{
    [SerializeField] bool isCorrectOne;
    [SerializeField] string descripcion;
    public override void Interact()
    {
        if (!isCorrectOne)
        {
            Debug.Log(descripcion);
        }
        else
        {
            Debug.Log("Las flores se extienden con gracia, presume sus colores con orgullo. Seria buen sujeto para una foto.");
        }
    }

    public override void changeCamera()
    {
        
    }

    public override string GetDescription()
    {
        return "Apretá E para examinar las flores";
    }
}
