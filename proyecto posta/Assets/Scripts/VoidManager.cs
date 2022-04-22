using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VoidManager : MonoBehaviour
{
    [SerializeField] Transform cameraPos;
    [SerializeField] GameObject door;
    [SerializeField] GameObject collider;
    private void Start()
    {
        GameEvents.current.kevinStoppedTalking += OpenDoor;
    }

    void OpenDoor()
    {
        GameObject playCam = GameObject.Find("PlayCam");
        float zz = GameObject.FindGameObjectWithTag("Player").transform.position.z;
        cameraPos.position = new Vector3(cameraPos.position.x, cameraPos.position.y, zz);
        door.transform.position = new Vector3(door.transform.position.x, door.transform.position.y, zz);
        //collider.transform.position = new Vector3(collider.transform.position.x, collider.transform.position.y, zz);
        door.SetActive(true);
        //collider.SetActive(true);
        //collider.transform.position = new Vector3(collider.transform.position.x, collider.transform.position.y, zz);
        playCam.GetComponent<CinemachineVirtualCamera>().Follow = cameraPos;
        playCam.GetComponent<CinemachineVirtualCamera>().LookAt = cameraPos;
    }
}
