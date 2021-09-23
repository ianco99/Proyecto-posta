using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakableGlass : MonoBehaviour
{
    [SerializeField] GameObject maceta;

    private void OnCollisionEnter(Collision other)
    {

        if(other.gameObject == maceta)
        {
            Destroy(gameObject);
        }
    }
}
