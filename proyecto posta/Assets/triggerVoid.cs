using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class triggerVoid : MonoBehaviour
{
    [SerializeField] Transform councilPos;
    [SerializeField] GameObject Council;
    [SerializeField] Transform cameraPos;
    [SerializeField] GameObject dialogue;
    private void OnTriggerEnter(Collider other)
    {
        gameManager.instance.UpdateGameState(GameState.Dialogue);
        GameObject.FindGameObjectWithTag("Player").GetComponent<movementReflect>().enabled = false;
        dialogue.GetComponent<ReadTxt>().StartDialogue("Void.txt", 0,7,false);
        GameObject playCam = GameObject.Find("PlayCam");
        float zz = GameObject.FindGameObjectWithTag("Player").transform.position.z;
        cameraPos.position = new Vector3(cameraPos.position.x, cameraPos.position.y, zz);
        playCam.GetComponent<CinemachineVirtualCamera>().Follow = cameraPos;
        playCam.GetComponent<CinemachineVirtualCamera>().LookAt = cameraPos;
        float z = GameObject.FindGameObjectWithTag("Player").transform.position.z;
        councilPos.position = new Vector3(councilPos.position.x, councilPos.position.y, z);
        Instantiate(Council, councilPos.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
