using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorFuctionality : MonoBehaviour
{
    public bool canOpen = false;
    public GameObject TriggerArea;
    private void Start()
    {
        GameEvents.current.TalkedToKevin += OnDoorwayOpen;
    }
    private void OnDoorwayOpen()
    {
        TriggerArea.SetActive(true);
    }
}
