using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atrilController : Interactable1
{
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

        Debug.Log("moviendo atril ayeee");
        on = !on;
        StartCoroutine("moverAtril", on);
        student.gameObject.SetActive(false);
    }

    public override string GetDescription()
    {
        return "Apreta la " + "E" + " para apagar/prender la luz.";
    }

    IEnumerator moverAtril(bool on)
    {
        while (on)
        {
            //sinwaves eoeoeo
        }

    }
}
