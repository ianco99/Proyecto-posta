using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jardinManager : MonoBehaviour
{
    [SerializeField] GameObject generador;
    [SerializeField] GameObject sprayerController;
    [SerializeField] GameObject[] flowers;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.activatingSpray += sprayActivate;
        GameEvents.current.pickingFlowers += flowersActivate;
    }

    void sprayActivate()
    {
        sprayerController.tag = "Interactable";
    }

    void flowersActivate()
    {
        foreach (GameObject flower in flowers)
        {
            flower.tag = "Interactable";
        }
    }
}
