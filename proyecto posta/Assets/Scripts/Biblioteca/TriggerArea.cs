using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trakate");
        if (other.transform.tag == "Player" && other.GetComponent<PlayerManager>().bibliotecaPostaPuzzles == 1)
        {
            Debug.Log("RAKTATAT");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
