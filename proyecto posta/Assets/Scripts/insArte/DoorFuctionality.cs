using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorFuctionality : MonoBehaviour
{
    public bool canOpen = false;
    public GameObject TriggerArea;
    public BoxCollider door;
    private void Start()
    {
        GameEvents.current.kevinStoppedTalking += OnDoorwayOpen;
    }
    private void OnDoorwayOpen()
    {
        door.isTrigger = true;
        Debug.Log("cato");
        TriggerArea.SetActive(true);
    }
}
