using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    public TMPro.TextMeshProUGUI interactionText;
    public Interactable1 focus;
    public UnityEngine.UI.Image interactionHoldProgress;
    public GameObject interactionHoldGO;
    public float holdTime;
    [SerializeField] Transform raycastOrigin;
    [SerializeField] float raycastDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
    }

    void Interact()
    {
        bool successfulHit = false;

        // if (Input.GetKeyDown(KeyCode.E)){

        Vector3 origin = new Vector3(raycastOrigin.transform.position.x, raycastOrigin.transform.position.y, raycastOrigin.transform.position.z);
        RaycastHit hit;
        Physics.Raycast(origin, this.transform.forward, out hit, raycastDistance);
        if (hit.collider != null && hit.transform.gameObject.tag == "Interactable")
        {
            Interactable1 interactable = hit.collider.GetComponent<Interactable1>();
            if (interactable != null)
            {
                HandleInteraction(interactable);
                interactionText.text = interactable.GetDescription();
                successfulHit = true;

                interactionHoldGO.SetActive(interactable.interactionType == Interactable1.InteractionType.Hold);

            }
        }

        if (!successfulHit)
        {
            interactionText.text = "";
            interactionHoldGO.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        bool successfulHit = false;
        if (other != null && other.transform.gameObject.tag == "Interactable")
        {
            Interactable1 interactable = other.GetComponent<Interactable1>();
            if (interactable != null)
            {
                HandleInteraction(interactable);
                interactionText.text = interactable.GetDescription();
                successfulHit = true;

                interactionHoldGO.SetActive(interactable.interactionType == Interactable1.InteractionType.Hold);

            }
        }

        if (!successfulHit)
        {
            interactionText.text = "";
            interactionHoldGO.SetActive(false);
        }
    }
    void HandleInteraction(Interactable1 interactable)
    {
        KeyCode key = KeyCode.E;
        switch (interactable.interactionType)
        {
            case Interactable1.InteractionType.Click:
                if (Input.GetKeyDown(key))
                {
                    interactable.Interact();
                }
                break;
            case Interactable1.InteractionType.Hold:
                if (Input.GetKey(key))
                {
                    interactable.IncreaseHoldTime();
                    if (interactable.GetHoldTime() > holdTime)
                    {
                        interactable.Interact();
                        interactable.ResetHoldTime();
                    }
                }
                else
                {
                    interactable.ResetHoldTime();
                }
                interactionHoldProgress.fillAmount = interactable.GetHoldTime();
                break;
            case Interactable1.InteractionType.Minigame:
                //minigame
                break;

            default:
                throw new System.Exception("Unsupported type of interactable.");
        }
    }
}
