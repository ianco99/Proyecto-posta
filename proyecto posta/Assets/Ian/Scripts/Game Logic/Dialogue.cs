﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Dialogue : Interactable1
{
    public bool alreadyTalked = false;

    GameObject TextDialogue;
    public ReadTxt script;
    GameObject player;
    [SerializeField] Animator anim;
    int scene;
    KevinMOv mover;
    public Transform proxPos;
    int i = 0;
    public Transform salida;

    // Start is called before the first frame update
    void Start()
    {
        TextDialogue = GameObject.FindWithTag("Text");
        script = TextDialogue.GetComponent<ReadTxt>();
        player = GameObject.FindGameObjectWithTag("Player");
        GameEvents.current.kevinStoppedTalking += EndLevel;
        mover = this.GetComponent<KevinMOv>();
    }

    //public void Talk(string nameFile, int lineaprinc, int lineaFin)
    //{
    //    script.StartDialogue(nameFile, lineaprinc, lineaFin);
    //    FindObjectOfType<LevelManager>().hasTalkedToKevin = true;
    //    GameEvents.current.TalkedToKevinFunct();
    //    //gameManager.instance.NextLevel();
    //    //gameManager.instance.UpdateGameState(GameState.Dialogue);
    //}
    public override string GetDescription()
    {
        return "Apretá [E] para hablar con <color=green>Kevin</color>";  
    }

    public override void changeCamera()
    {
        
    }
    public override void Interact()
    {
        anim.SetBool("Action", false);
        switch (gameManager.instance.level)
        {
            case 1:
                Debug.Log("DAALE");
                if (!alreadyTalked)
                {
                    script.StartDialogue("Biblioteca.txt", 5, 7, true);
                    i++;
                    
                    
                }
                if (alreadyTalked && i == 1)
                {
                    i++;
                    script.StartDialogue("Biblioteca.txt", 9, 16, true);
                    StartCoroutine("Hardcodeado");
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().bibliotecaPostaPuzzles++;
                }
                break;
            case 2:
                Debug.Log("DAALE");
                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().bibliotecaPuzzles == 0){
                    Debug.Log("El gordo");
                    
                    alreadyTalked = !alreadyTalked;
                    //talk "aaa finn ayuda quiero entrar"
                }
                else if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().bibliotecaPuzzles == 2)
                {
                    Debug.Log("juntame las temperas querido");
                    script.StartDialogue("InstitutoArte.txt", 14, 19, true);
                    GameEvents.current.KevinArtSupplies();
                }
                else if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().bibliotecaPuzzles == 5)
                {
                    anim.Play("KevinDraw");
                    script.StartDialogue("InstitutoArte.txt", 26, 31, true);
                    Debug.Log("Garcias, me espantas a los boludos del medio que me tapan la vista?");
                    GameEvents.current.KevinNeedsScaring();
                  
                }
                else if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().bibliotecaPuzzles == 8)
                {
                    script.StartDialogue("InstitutoArte.txt", 35, 44, true);
                    
                }
                break;
            case 4:
                if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().jardinPuzzles == 1)
                {
                    //GameEvents.current.ActivateSpray();
                    //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().jardinPuzzles++;
                    //script.StartDialogue("Jardin.txt", 10, 18, false);
                }
                else if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().jardinPuzzles == 4)
                {
                    script.StartDialogue("Jardin.txt", 26, 29, true);
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().jardinPuzzles++;
                }
                else if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().jardinPuzzles == 5)
                {
                    script.StartDialogue("Jardin.txt", 30, 32, true);
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().jardinPuzzles++;
                }
                else if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().jardinPuzzles == 7)
                {
                    script.StartDialogue("Jardin.txt", 33, 36, false);
                }
                break;
        }
    }
    public void Acting(bool active)
    {
        anim.SetBool("Action", active);
    }
    void EndLevel()
    {
        switch (gameManager.instance.level)
        {
            case 1:
                if (!alreadyTalked && i == 1)
                {
                    mover.MoveToThisPoint(proxPos.position, false);
                    alreadyTalked = !alreadyTalked;
                }
                
                break;
            case 2:
                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().bibliotecaPuzzles == 8)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                break;
        }
        
    }

    IEnumerator Hardcodeado()
    {
        yield return new WaitForSeconds(2);
        mover.MoveToThisPoint(salida.position, false);
    }
}
