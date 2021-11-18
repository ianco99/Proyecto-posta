using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventFade : MonoBehaviour
{
    public void Faded()
    {
        GameEvents.current.FadedIn();
    }
}
