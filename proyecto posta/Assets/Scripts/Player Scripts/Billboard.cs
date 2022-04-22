using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 Camara = new Vector3(Camera.main.transform.position.x, 1.4067f, Camera.main.transform.position.z);
        transform.LookAt(Camara);
    }
}
