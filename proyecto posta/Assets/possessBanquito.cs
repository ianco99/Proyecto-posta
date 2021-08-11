using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class possessBanquito : Interactable1
{
    [SerializeField] GameObject luz;
    Rigidbody rb;
    bool on = false;
    GameObject player;
    int movimiento;
    public float fuerza;
    [SerializeField] GameObject student;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    public override void Interact()
    {
        
        Debug.Log("moviendo banquito ayeee");
        on = !on;
        StartCoroutine("moverBanquito", on);
        student.gameObject.SetActive(false);
    }

    public override string GetDescription()
    {
        return "Apreta la " + "E" + " para apagar/prender la luz.";
    }
    
    IEnumerator moverBanquito(bool on)
    {
        while (on)
        {
            yield return new WaitForSeconds(1f);
            switch (movimiento)
            {
                case 0:
                    //romper la barrera divisoria de la velocidad de la luz por la raiz cuadrada del movimiento unfirome rectilineo de cuando una bla es disparada a una velocidad de aproximadamente uno sobre cuatro negros de  mierda son todas unas putas por favor sacame de aca eu doncd 
                    rb.AddForce(fuerza, 0f, 0f);
                    movimiento++;
                    break;
                case 1:
                    rb.AddForce(-fuerza, 0f, 0f);
                    movimiento++;
                    
                    break;
                case 2:
                    rb.AddForce(0f, fuerza, 0f);
                    movimiento++;
                    break;
                case 3:
                    rb.AddForce(0f, -fuerza, 0f);
                    movimiento++;
                    break;
                case 4:
                    rb.AddForce(0f, 0f, fuerza);
                    movimiento++;
                    
                    break;
                case 5:
                    rb.AddForce(0f, 0f, -fuerza);
                    movimiento++;
                    break;
                case 6:
                    rb.AddForce(-fuerza, 0f, 0f);
                    movimiento++;
                    break;
                case 7:
                    rb.AddForce(fuerza, 0f, 0f);
                    movimiento++;
                    break;
                case 8:
                    movimiento = 0;
                    break;
            }
        }
        
    }
}
