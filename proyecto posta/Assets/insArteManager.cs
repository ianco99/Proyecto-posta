using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class insArteManager : MonoBehaviour
{
    public GameObject[] artSupplies;
    public GameObject[] students;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.kevinArtSupplies += PickUpMaterials;
        GameEvents.current.needScaring += ScareStudents;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PickUpMaterials()
    {
        foreach (GameObject supply in artSupplies)
        {
            supply.GetComponent<Outline>().enabled = true;
            supply.tag = "Interactable";
        }
    }

    void ScareStudents()
    {
        foreach(GameObject student in students)
        {
            student.GetComponent<Outline>().enabled = true;
        }
    }
}
