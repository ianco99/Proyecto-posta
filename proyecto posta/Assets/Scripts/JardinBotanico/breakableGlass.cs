using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakableGlass : MonoBehaviour
{
    [SerializeField] GameObject maceta;
    [SerializeField] GameObject particulas;
    private void OnCollisionEnter(Collision other)
    {

        if(other.gameObject == maceta)
        {
            
            particulas.SetActive(true);
            Destroy(maceta.GetComponent<LineRenderer>());
            Destroy(maceta.GetComponent<HingeJoint>());
            Destroy(gameObject);
        }
    }
}
