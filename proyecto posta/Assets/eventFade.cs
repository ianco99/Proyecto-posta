using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventFade : MonoBehaviour
{
    [SerializeField] GameObject esto;
    public void Faded()
    {
        GameEvents.current.FadedIn();
    }

    public void deactivate()
    {
        esto.SetActive(false);
    }
}
