using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba : MonoBehaviour
{

    KevinMOv kev;
    public GameObject kevin;
    public GameObject arrte;

    // Start is called before the first frame update
    void Start()
    {
        kev = kevin.GetComponent<KevinMOv>();
        kev.MoveToThisPoint(new Vector3(arrte.transform.position.x, arrte.transform.position.y, arrte.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
