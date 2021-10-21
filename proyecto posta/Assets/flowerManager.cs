using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerManager : Interactable1
{
    [SerializeField] bool isCorrectOne;
    [SerializeField] string descripcion;
    [SerializeField] string segundaDesc;
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
                Debug.Log("Las flores se extienden con gracia, presume sus colores con orgullo. Seria buen sujeto para una foto.");
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().jardinPuzzles++;
                GameEvents.current.PickedFlowers();
                GameEvents.current.ActivateSpray();
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().jardinPuzzles++;
                GameObject.FindGameObjectWithTag("Text").GetComponent<ReadTxt>().StartDialogue("Jardin.txt", 10, 18, false);
            }
        }
        else
        {
            Debug.Log(segundaDesc);
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
