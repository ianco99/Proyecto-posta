using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacciones : MonoBehaviour
{
    static string name = "Intercciones.txt";
    public int lineaprinc;
    public int lineafin;
    bool apretado = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(apretado){

        }
    }

    public void OnTriggerEnter(Collider collider){
        apretado = true;
    }

    public void OnTriggerExit(Collider collider){
        apretado = false;
    }
}
