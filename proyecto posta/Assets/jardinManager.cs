using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jardinManager : MonoBehaviour
{
    public GameObject generador;
    public GameObject sprayerController;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.activatingSpray += sprayActivate;
    }

    void sprayActivate()
    {
        sprayerController.tag = "Interactable";
    }
}
