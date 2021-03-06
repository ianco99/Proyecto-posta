using UnityEngine;
using Cinemachine;
public class Lightbulb : Interactable1
{
    public GameObject light1, light2, light3, light4;
    public bool isOn = true;
    public bool inverter = false;
    //hola soy blastermanmnmnmnmnmmm

    private void Update()
    {
        if(!light1.activeSelf && light2.activeSelf && !light3.activeSelf && !light4.activeSelf)
        {
            GameEvents.current.FinishedFlowerPuzzle();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().jardinPuzzles++;
        }
    }
    void UpdateLight1()
    {
        light1.SetActive(!light1.activeSelf);
        light2.SetActive(!light2.activeSelf);
    }
    void UpdateLight2()
    {
        light2.SetActive(!light2.activeSelf);
        light4.SetActive(!light4.activeSelf);
    }
    void UpdateLight3()
    {
        light2.SetActive(!light2.activeSelf);
        light3.SetActive(!light3.activeSelf);
        light4.SetActive(!light4.activeSelf);
    }

    public override string GetDescription()
    {
        return description;
    }

    public override void changeCamera()
    {
        GameObject playCam = GameObject.Find("PlayCam");
        playCam.GetComponent<CinemachineVirtualCamera>().Follow = cameraPos;
        playCam.GetComponent<CinemachineVirtualCamera>().LookAt = cameraPos;;
    }
    public override void Interact()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UpdateLight1();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UpdateLight2();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UpdateLight3();
        }

    }
}
