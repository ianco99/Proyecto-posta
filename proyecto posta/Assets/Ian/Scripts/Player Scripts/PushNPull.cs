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
    [SerializeField] CharacterController controller;
    public float velocidad;
    float initialDrag;
    float initialAngularDrag;
    Animator anim;
    public GameObject AudioManager;
    AudioManager script;

    void Start()
    {
        script = AudioManager.GetComponent<AudioManager>();
        anim = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        PushAndPull();
    }
    void PushAndPull()
    {
        if (Input.GetKey(KeyCode.R) && !interacting && controller.isGrounded)
        {

            Vector3 origin = new Vector3(raycastOrigin.transform.position.x, raycastOrigin.transform.position.y, raycastOrigin.transform.position.z);
            RaycastHit hit;
            Physics.Raycast(origin, this.transform.forward, out hit, raycastDistance);
            Debug.DrawRay(origin, this.transform.forward, Color.green, 20f, false);
            if (hit.collider != null && hit.transform.gameObject.tag == "Pushable")
            {
                
                interacting = true;
                script.Play("Push");
                player.GetComponent<Movement>().speed = 2f;
                interacted = hit.transform.gameObject;
                initialAngularDrag = interacted.GetComponent<Rigidbody>().angularDrag;
                initialDrag = interacted.GetComponent<Rigidbody>().drag;
                Debug.Log("sus");
                anim.SetBool("Pushing", true);
            }
        }
        else if (Input.GetKey(KeyCode.R) && interacting)
        {
            if(Vector3.Distance(interacted.transform.position, this.transform.position) > 2f)
            {
                StopPushing(interacted);
            }
            if(!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                interacted.GetComponent<Rigidbody>().isKinematic = true;
            }
            else
            {
                interacted.GetComponent<Rigidbody>().isKinematic = false;
            }
            Vector3 moveObject = new Vector3(this.transform.position.x, interacted.transform.position.y, interacted.transform.position.z);
            interacted.GetComponent<Rigidbody>().velocity = player.GetComponent<Movement>().direction * player.GetComponent<Movement>().speed;
            interacted.GetComponent<Rigidbody>().drag = 0f;
            interacted.GetComponent<Rigidbody>().angularDrag = 0f;

            if (player.GetComponent<Movement>().direction.x < -0.0001 || player.GetComponent<Movement>().direction.z < -0.0001)
            {
                Debug.Log("ARRASTRANDO");
                anim.SetBool("Pushing", true);
            }
            else if (player.GetComponent<Movement>().direction.x > 0.0001 || player.GetComponent<Movement>().direction.z > 0.0001)
            {
                Debug.Log("EMPUJANDO");
                anim.SetBool("Pushing", true);
            }

            
        }
        else if (Input.GetKeyUp(KeyCode.R) && interacting)
        {
            StopPushing(interacted);
        }
    }

    void StopPushing(GameObject interacted)
    {
        interacted.GetComponent<Rigidbody>().isKinematic = false;
        interacted.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        interacted.GetComponent<Rigidbody>().drag = initialDrag;
        interacted.GetComponent<Rigidbody>().angularDrag = initialAngularDrag;
        interacting = false;
        script.Stop("Push");
        interacted = null;
        player.GetComponent<Movement>().speed = 6f;
        anim.SetBool("Pushing", false);
        anim.SetBool("PushingVolteado", false);
    }
}
