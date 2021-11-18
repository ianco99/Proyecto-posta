using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Dialogue : Interactable1
{
    public bool alreadyTalked = false;

    GameObject TextDialogue;
    public ReadTxt script;
    GameObject player;
    PlayerManager playerStats;
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
    private void Update()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
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
                    playerStats.bibliotecaPostaPuzzles++;
                }
                break;
            case 2:
                Debug.Log("DAALE");
                 if(playerStats.bibliotecaPuzzles == 2)
                {
                    Debug.Log("juntame las temperas querido");
                    script.StartDialogue("InstitutoArte.txt", 14, 19, true);
                    GameEvents.current.KevinArtSupplies();
                }
                else if(playerStats.bibliotecaPuzzles == 5)
                {
                    anim.Play("KevinDraw");
                    script.StartDialogue("InstitutoArte.txt", 26, 31, true);
                    Debug.Log("Garcias, me espantas a los boludos del medio que me tapan la vista?");
                    GameEvents.current.KevinNeedsScaring();
                  
                }
                else if (playerStats.bibliotecaPuzzles == 8)
                {
                    script.StartDialogue("InstitutoArte.txt", 35, 44, true);
                    
                }
                break;
            case 4:
                if(playerStats.jardinPuzzles == 1)
                {
                    //GameEvents.current.ActivateSpray();
                    //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().jardinPuzzles++;
                    //script.StartDialogue("Jardin.txt", 10, 18, false);
                }
                else if(playerStats.jardinPuzzles == 4)
                {
                    script.StartDialogue("Jardin.txt", 26, 29, true);
                    playerStats.jardinPuzzles++;
                }
                else if (playerStats.jardinPuzzles == 5)
                {
                    script.StartDialogue("Jardin.txt", 30, 32, true);
                    playerStats.jardinPuzzles++;
                }
                else if (playerStats.jardinPuzzles == 7)
                {
                    script.StartDialogue("Jardin.txt", 33, 36, false);
                }
                break;
            case 5:
                Debug.Log("eyeyeyye");
                break;
            case 3:
                if(playerStats.cuartoKevinDialogues == 1)
                {
                    script.StartDialogue("CuartoDeKevin.txt", 3, 12, false);
                    playerStats.cuartoKevinDialogues++;
                }
                
                break;
            case 6:
                if(playerStats.universidadPuzzles == 0)
                {
                    Debug.Log("heyyy hay fila tf??");
                    GameEvents.current.StoppedTalking();
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
