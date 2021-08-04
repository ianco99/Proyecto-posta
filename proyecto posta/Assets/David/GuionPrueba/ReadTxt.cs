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
    public bool cambiaDialogo = true;

    // Start is called before the first frame update
    void Start()
    {
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
            StartCoroutine(waitTen(lineatfin));
            lineatfin++;
            cambiaDialogo = false;
        }
        //else if (Input.GetKeyDown("space") && cor) StartDialogue(nombFile, 5, 7);
        
        if(Input.GetKeyDown("up")){
            estaPresente = true;
        }
    }

    public void StartDialogue(string name, int lineaprinc, int lineaFin){
        //gameManager.instance.UpdateGameState(GameState.Dialogue);
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
        gameManager.instance.UpdateGameState(GameState.Playing);
       Tex.SetActive(false);
    }

    void NextDialogue(int lineafin){
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
                            panel.GetComponent<Image>().material.color = new Color(255, 255, 0);
                            break;
                         case  "TFinn": 
                            panel.GetComponent<Image>().material.color = new Color(255, 255, 0);
                            nomb[0] = "Finn";
                            break;
                        case "Dialogo Interno de Finn":
                            panel.GetComponent<Image>().material.color = new Color(255, 255, 100);
                            break;
                        case "Kevin":
                            panel.GetComponent<Image>().material.color = new Color(0, 255, 255);
                            break;
                        case "Profesor":
                            panel.GetComponent<Image>().material.color = new Color(255, 0, 255);
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
        texto.text = "";
        foreach(char letter in sentence.ToCharArray()){
            texto.text += letter;
            yield return null;
        }
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


    IEnumerator waitTen(int lineaFin){
        yield return new WaitForSeconds(10f);
        NextDialogue(lineaFin);
        cambiaDialogo = true;
    }

    /* IEnumerator popUP(int lineaFin){
        estaPresente = false;
        Tex.SetActive(true);
        yield return new WaitUntil(() => estaPresente);
        Tex.SetActive(false);
        NextDialogue(lineaFin);
    }*/
}
