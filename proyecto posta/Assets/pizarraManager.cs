using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pizarraManager : Interactable1
{
    [SerializeField] GameObject luz;
    bool on = false;
    GameObject player;
    int movimiento;
    public float fuerza;
    [SerializeField] GameObject student;
    [SerializeField] float startTime;
    float currentTime = 0;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void Interact()
    {

        
        on = !on;
        while (on)
        {

            Dibujo(on);
        }
        student.gameObject.SetActive(false);
    }

    public override string GetDescription()
    {
        return "Apreta la " + "E" + " para apagar/prender la luz.";
    }

    void Dibujo(bool on)
    {
        
            if(currentTime > startTime)
            {
                Debug.Log("moviendo pizarra ayeee");
                on = !on;
            }
            currentTime += Time.deltaTime;

        Debug.Log("Terminó");
    }
}
