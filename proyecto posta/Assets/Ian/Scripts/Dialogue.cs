using System;
using UnityEngine;

public class Dialogue : Interactable1
{
    public bool alreadyTalked = false;

    GameObject TextDialogue;
    ReadTxt script; 
    // Start is called before the first frame update
    void Start()
    {
        TextDialogue = GameObject.FindWithTag("Text");
        script = TextDialogue.GetComponent<ReadTxt>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Talk(string nameFile, int lineaprinc, int lineaFin)
    {
        script.StartDialogue(nameFile, lineaprinc, lineaFin);
        FindObjectOfType<LevelManager>().hasTalkedToKevin = true;
        GameEvents.current.TalkedToKevinFunct();
        //gameManager.instance.NextLevel();
        //gameManager.instance.UpdateGameState(GameState.Dialogue);
    }
    public override string GetDescription()
    {
        if (alreadyTalked)
        {
            return "Andá a la <color=red>puerta</color>";
        }
        else
        {
            return "Apretá [E] para hablar con <color=green>Kevin</color>";
        }
    }

    public override void Interact()
    {
        switch (gameManager.instance.level)
        {
            case 1:
                if (!alreadyTalked)
                {
                    Talk("Biblioteca.txt", 7, 14);
                    alreadyTalked = !alreadyTalked;
                }
                break;
            case 2:
                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().bibliotecaPuzzles == 0)
                {
                    Debug.Log("El gordo");
                    alreadyTalked = !alreadyTalked;
                    //talk "aaa finn ayuda quiero entrar"
                }
                else if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().bibliotecaPuzzles == 2)
                {
                    Debug.Log("juntame las temperas querido");
                }
                break;
        }

        

        
        
    }
 
    
}
