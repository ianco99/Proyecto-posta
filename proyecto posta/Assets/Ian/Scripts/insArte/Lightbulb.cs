using UnityEngine;
using Cinemachine;
public class Lightbulb : Interactable1
{
    public GameObject light1, light2, light3, light4;
    public bool isOn;
    public bool inverter = false;
    //hola soy blastermanmnmnmnmnmmm
    void UpdateLight1()
    {
        light1.SetActive(!light1.activeSelf);
    }
    void UpdateLight2()
    {
        light1.SetActive(!light1.activeSelf);
        light4.SetActive(!light4.activeSelf);
    }
    void UpdateLight3()
    {
        light1.SetActive(!light1.activeSelf);
        light2.SetActive(!light2.activeSelf);
        light3.SetActive(!light3.activeSelf);
        light4.SetActive(!light4.activeSelf);
    }

    public override string GetDescription()
    {
        if (isOn) return "Press [E] to turn <color=red>off</color=red> the light.";
        return "Press [E] to turn <color=green>on</color> the light.";
    }

    public override void changeCamera()
    {
        GameObject playCam = GameObject.Find("PlayCam");
        playCam.GetComponent<CinemachineVirtualCamera>().Follow = cameraPos;
        playCam.GetComponent<CinemachineVirtualCamera>().LookAt = cameraPos;
        playCam.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>().m_CameraDistance = 17;
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
