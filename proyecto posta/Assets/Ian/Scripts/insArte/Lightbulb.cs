using UnityEngine;

public class Lightbulb : Interactable1
{
    public GameObject[] m_light;
    public bool isOn;
    public bool inverter = false;

    private void Start()
    {
        UpdateLight();
    }

    void UpdateLight()
    {
        
        foreach (GameObject light in m_light)
        {
            light.SetActive(isOn);
        }
    }

    void InvertLight()
    {
        foreach (GameObject light in m_light)
        {
            light.SetActive(!light.activeSelf);
        }
    }

    public override string GetDescription()
    {
        if (isOn) return "Press [E] to turn <color=red>off</color=red> the light.";
        return "Press [E] to turn <color=green>on</color> the light.";
    }

    public override void Interact()
    {
        isOn = !isOn;
        if (!inverter)
            UpdateLight();
        else
            InvertLight();

    }
}
