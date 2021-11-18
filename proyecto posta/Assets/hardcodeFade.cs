using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hardcodeFade : MonoBehaviour
{
    public GameObject camera;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().bibliotecaPuzzles == 0)
            {
                camera.GetComponent<CameraWallSeeThrough>().enabled = true;
            }
        }
    }
}
