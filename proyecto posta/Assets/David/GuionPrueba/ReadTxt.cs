using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class ReadTxt : MonoBehaviour
{
    public Text texto;
    public GameObject panel;
    public GameObject Tex;
    public Text Nombre;
    string[] textito; 
    bool x = false;
    bool cor = true;
    public int cantPal = 0;
    public bool estaPresente; 
    public string nombFile;
    public string nombre = "";
    public int LineafinWW = 0;
    public int lineatfin = 1;
    public bool cambiaDialogo = false;
    float countPitch = 2f; 
    public GameObject AudioManager;
    AudioManager script;
    public bool sentTrue = false;


    // Start is called before the first frame update
    void Start()
    {
        script = AudioManager.GetComponent<AudioManager>();
        estaPresente = false;
    }

    public bool getEstaPresente(){
        return estaPresente;
    }

    public void setEstaPresente(bool estaPresente){

        this.estaPresente = estaPresente;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space")  && x && cor){
            if(cantPal<textito.Length && nombre != "TFinn"){
              NextDialogue(LineafinWW);
            }
        }
        if(nombre == "TFinn" && cambiaDialogo){
           // StartCoroutine(waitTen(lineatfin));
            cambiaDialogo = false;
        }
        //else if (Input.GetKeyDown("space") && cor) StartDialogue(nombFile, 5, 7);
        
    }

    public void StartDialogue(string name, int lineaprinc, int lineaFin){
        if(gameManager.instance.level != 0) gameManager.instance.UpdateGameState(GameState.Dialogue);
        x = true;
        string dataPath = Application.dataPath + "/TXT/" + name;
        textito = File.ReadAllLines(dataPath);
        if (lineaFin <= 0) lineaFin = textito.Length - 1;        
        LineafinWW = lineaFin;
        cantPal = lineaprinc;
        Tex.SetActive(true);
        NextDialogue(lineaFin);
    }

    void EndDialogue(){ 
        x = false;
        GameEvents.current.StoppedTalking();
        gameManager.instance.UpdateGameState(GameState.Playing);
       Tex.SetActive(false);
    }

    public void NextDialogue(int lineafin){
        if (cantPal == lineafin) EndDialogue();
        else{
            if (textito[cantPal] == "FIN")
            {
                texto.text = "";
                EndDialogue();
            }
            else
            {
                StopAllCoroutines();
                string[] nomb = textito[cantPal].Split(':');
                if (nomb[0] == "Tiempo")
                {
                    StartCoroutine(waitTime(float.Parse(nomb[1]), lineafin));
                }
                else if (nomb[0] == "Bool")
                {
                    StartCoroutine(waitUntil(lineafin));
                }
                else
                {
                    nombre = nomb[0];
                    switch (nomb[0])
                    {
                        case "Finn":
                           // panel.GetComponent<Image>().material.color = new Color(255, 255, 0);
                            break;
                         case  "TFinn": 
                           // panel.GetComponent<Image>().material.color = new Color(255, 255, 0);
                            nomb[0] = " Dialogo de Finn";
                            break;
                        case "Kevin":
                           // panel.GetComponent<Image>().material.color = new Color(0, 255, 255);
                            break;
                        case "Profesor":
                            //panel.GetComponent<Image>().material.color = new Color(255, 0, 255);
                            break;
                    }
                    StartCoroutine(TypeSentence(nomb[1]));
                    Nombre.text = nomb[0];
                }
                cantPal++;
            }
        }
        
    }

    public void RepeatDialogue(string nameFile, int numLineaPrinc, int numLineaFin){
        
    }

    IEnumerator TypeSentence(string sentence){
        StartCoroutine(PlayLetter());
        sentTrue = true;
        Tex.SetActive(true);
        texto.text = "";
        foreach(char letter in sentence.ToCharArray()){
            texto.text += letter;
            yield return null;
        }
        sentTrue = false;
    }

    IEnumerator waitTime(float tiempo, int lineaFin){
        Tex.SetActive(false);
        cor = false;
        yield return new WaitForSeconds(tiempo);
        cor = true;
        Tex.SetActive(true);
        NextDialogue(lineaFin);
    }

    IEnumerator waitUntil(int lineaFin){
        estaPresente = false;
        Tex.SetActive(false);
        cor = false;
        yield return new WaitUntil(() => estaPresente);
        cor = true;
        Tex.SetActive(true);
        NextDialogue(lineaFin);
    }


    public IEnumerator waitTen(){
        yield return new WaitForSeconds(5f);
        Tex.SetActive(false);
    }

    IEnumerator PlayLetter(){
        AudioSounds[] sounds = script.sounds;
        AudioSounds s = sounds[3];
        s.source.pitch = countPitch;
        switch(countPitch){
	        case 2f:
		        countPitch = 0.5f;

		        break;
	        case 1.5f:
	        	countPitch = 1f;
	        	break;
        	case 0.5f:
	        	countPitch = 1.5f;
	        	break;
	        case  3f:
		        countPitch = 2f;
        		break;
            case 1f:
                countPitch = 2.5f;
                break;  
            case 2.5f:
                countPitch = 3f;
                break;          
        }
        script.Play("Letra");
        Debug.Log(countPitch);
        yield return new WaitForSeconds(0.1f);
        if(sentTrue) StartCoroutine(PlayLetter());

    }

    /* IEnumerator popUP(int lineaFin){
        estaPresente = false;
        Tex.SetActive(true);
        yield return new WaitUntil(() => estaPresente);
        Tex.SetActive(false);
        NextDialogue(lineaFin);
    }*/
}
