using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class insArteManager : MonoBehaviour
{
    public GameObject[] artSupplies;
    public GameObject[] students;
    public GameObject[] possesables;
    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.kevinArtSupplies += PickUpMaterials;
        GameEvents.current.needScaring += ScareStudents;
        GameEvents.current.needScaring += preparePossesables;
        GameEvents.current.kevinStoppedTalking += hardcodeadisimo;
    }

    void PickUpMaterials()
    {
        foreach (GameObject supply in artSupplies)
        {
            supply.GetComponent<Outline>().enabled = true;
            supply.tag = "Interactable";
        }
    }

    void hardcodeadisimo()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().bibliotecaPuzzles == 0)
        {
            camera.GetComponent<CameraWallSeeThrough>().enabled = true;
        }
        
    }

    void ScareStudents()
    {
        foreach(GameObject student in students)
        {
            
            student.GetComponent<Outline>().enabled = true;
            
        }
    }

    void preparePossesables()
    {
        Debug.Log("Funcion");
        foreach(GameObject possesable in possesables)
        {
            Debug.Log("Foreach");
            possesable.tag = "Possesable";
            Debug.Log("Terminó el foreach");
        }
    }
}
