using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class artSupply : Interactable1
{
    public bool alreadyTalked = false;
    [SerializeField] string descripcion;
    // Start is called before the first frame update
    public override string GetDescription()
    {
        return descripcion;
    }

    public override void changeCamera()
    {
        
    }
    public override void Interact()
    {
        if (!alreadyTalked)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().bibliotecaPuzzles++;
            Destroy(this.gameObject);
        }
    }
}
