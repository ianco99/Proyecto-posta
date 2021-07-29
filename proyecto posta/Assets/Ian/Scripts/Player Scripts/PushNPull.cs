using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushNPull : MonoBehaviour
{
    [SerializeField] float raycastDistance;
    public bool interacting = false;
    [SerializeField] GameObject interacted;
    [SerializeField] Transform raycastOrigin;
    [SerializeField] GameObject player;
    private void Start()
    {
    }
    void Update()
    {
        PushAndPull();
    }
    void PushAndPull()
    {
        if (Input.GetKeyDown(KeyCode.R) && !interacting)
        {

            Vector3 origin = new Vector3(raycastOrigin.transform.position.x, raycastOrigin.transform.position.y, raycastOrigin.transform.position.z);
            RaycastHit hit;
            Physics.Raycast(origin, this.transform.forward, out hit, raycastDistance);
            Debug.DrawRay(origin, this.transform.forward, Color.green, 20f, false);
            if (hit.collider != null && hit.transform.gameObject.tag == "Pushable")
            {
                Debug.Log("INTERACTING");
                interacting = true;

                player.GetComponent<Movement>().speed = 2f;
                interacted = hit.transform.gameObject;

            }
        }
        if (Input.GetKey(KeyCode.R) && interacting)
        {
            Vector3 moveObject = new Vector3(this.transform.position.x, interacted.transform.position.y, interacted.transform.position.z);
            interacted.GetComponent<Rigidbody>().velocity = player.GetComponent<Movement>().direction * player.GetComponent<Movement>().speed;
            if (player.GetComponent<Movement>().direction.x < -0.0001 || player.GetComponent<Movement>().direction.z < -0.0001)
            {
                Debug.Log("ARRASTRANDO");
            }
            else if (player.GetComponent<Movement>().direction.x > 0.0001 || player.GetComponent<Movement>().direction.z > 0.0001)
            {
                Debug.Log("EMPUJANDO");
            }
        }
        else if (Input.GetKeyUp(KeyCode.R) && interacting)
        {
            //interacted.transform.SetParent(null);
            interacting = false;
            interacted = null;
            player.GetComponent<Movement>().speed = 6f;
        }
    }
}
