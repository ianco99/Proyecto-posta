using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuartoKevinInicioTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameManager.instance.UpdateGameState(GameState.Dialogue);
            GameObject.FindGameObjectWithTag("Text").GetComponent<ReadTxt>().StartDialogue("CuartoDeKevin.txt", 0, 2, false);
            Destroy(gameObject);
        }
    }
}
