using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ReadTxt : MonoBehaviour
{
    public Text texto;
    public GameObject panel;
    public GameObject panel2;
    public GameObject Tex;
    public Text Nombre;
    string[] textito; 
    bool x = false;
    bool cor = true;
    public bool shouldPlayAfter = false;
    
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
    public UnityEngine.Sprite kevIm;
    public UnityEngine.Sprite finIm;
    public UnityEngine.Sprite profIm;
    public UnityEngine.Sprite pngVacio;
    
    //public 


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

    public void StartDialogue(string name, int lineaprinc, int lineaFin, bool playAfter){
        shouldPlayAfter = playAfter;
        if(gameManager.instance.level != 0) gameManager.instance.UpdateGameState(GameState.Dialogue);
        x = true;
        var textFile = Resources.Load<TextAsset>(name);
        //string txtContents = new StreamReader("Assets/Resources/" + name).ReadToEnd();
        //string[] lines = txtContents.Split("\n"[0]);
        //string dataPath = Directory.GetCurrentDirectory() + "/Assets/TXT/" + name;
        string dataPath = Application.streamingAssetsPath + "/" + name;
        textito = File.ReadAllLines(dataPath);
        if (lineaFin <= 0) lineaFin = textito.Length - 1;        
        LineafinWW = lineaFin;
        cantPal = lineaprinc;
        Tex.SetActive(true);
        NextDialogue(lineaFin);
    }

    public void EndDialogue(){ 
        x = false;
        GameEvents.current.StoppedTalking();
        if (shouldPlayAfter)
        {
            gameManager.instance.UpdateGameState(GameState.Playing);
        }
        //
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
                           panel2.GetComponent<Image>().sprite = finIm;
                           break;
                         case  "TFinn": 
                            panel2.GetComponent<Image>().sprite = finIm;
                            nomb[0] = " Dialogo de Finn";
                            break;
                        case "Kevin":
                            panel2.GetComponent<Image>().sprite = kevIm;
                            break;
                        case "Profesor":
                            panel2.GetComponent<Image>().sprite = profIm;
                            break;
                        default:
                            panel2.GetComponent<Image>().sprite = pngVacio;
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
