using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertaManager : MonoBehaviour
{
    [SerializeField] Transform puerta1;
    [SerializeField] Transform puerta2;
    [SerializeField] Transform transform1;
    [SerializeField] Transform transform2;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.StudentScared += OpenDoors;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OpenDoors()
    {
        puerta1.position = transform1.position;
        puerta2.position = transform2.position;
        puerta2.rotation = transform2.rotation;
        puerta1.rotation = transform1.rotation;
    }
}
