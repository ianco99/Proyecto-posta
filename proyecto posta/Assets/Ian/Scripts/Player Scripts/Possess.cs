using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possess : MonoBehaviour
{
    bool isPossesing;
    GameObject[] enemiesList;
    GameObject found;
    private Vector3 prevPos;
    public GameObject sprite;
    Animator anim;
    public GameObject AudioManager;
    [SerializeField] TMPro.TextMeshProUGUI interactionText;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        enemiesList = GameObject.FindGameObjectsWithTag("Possesable");
    }
    void Update()
    {
        if (isPossesing)
        {
            //interactionText.text = found.GetComponent<Interactable1>().GetDescription();
            //Debug.Log(interactionText.text);
            if (Input.GetKeyDown(KeyCode.E))
            {
                found.GetComponent<Interactable1>().Interact();
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                AudioManager.GetComponent<AudioManager>().Play("Poseer");
                this.GetComponent<Movement>().enabled = true;
                this.gameObject.transform.position = prevPos;
                sprite.GetComponent<SpriteRenderer>().enabled = true;
                anim.SetBool("BackFromPossess", true);
                anim.SetBool("Possessing", false);
                goBackToNormal();
                isPossesing = false;
            }
        }
        else
        {
            doPossess();
            Detect();
        }
    }

    void doPossess()
    {
        if (Input.GetKeyDown(KeyCode.F) && found != null)
        {
            anim.SetBool("Possessing", true);
            //Possesing();
        }
    }
    public void Possesing()
    {
        found.tag = "Interactable";
        isPossesing = true;
        prevPos = this.transform.position;
        this.transform.position = found.transform.position;
        this.GetComponent<CharacterController>().enabled = false;
        this.GetComponent<PushNPull>().enabled = false;
        sprite.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<Movement>().enabled = false;
    }

    public void goBackToNormal()
    {
        //this.gameObject.transform.position = prevPos;
        this.GetComponent<CharacterController>().enabled = true;
        this.GetComponent<PushNPull>().enabled = true;
        anim.Play("BackFromPosses");
        anim.SetBool("BackFromPossess", false);
        //sprite.GetComponent<SpriteRenderer>().enabled = true;
        anim.SetBool("Possessing", false);
    }

    void Detect()
    {
        
        GameObject possesable;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            try
            {
                enemiesList = GameObject.FindGameObjectsWithTag("Possesable");
                possesable = GetClosestEnemy(enemiesList).gameObject;

                if (Vector3.Distance(possesable.transform.position, transform.position) <= 10)
                {
                    possesable.GetComponent<Outline>().enabled = true;
                    found = possesable;
                }
            }
            catch(Exception e)
            {
                Debug.Log("LOL");
                Debug.LogException(e, this);
            }
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            try
            {
                foreach (GameObject potentialTarget in enemiesList)
                {
                    potentialTarget.GetComponent<Outline>().enabled = false;
                    //found = null;
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e, this);
            }
        }
    }

    Transform GetClosestEnemy(GameObject[] enemies)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget.transform;
            }
        }
        return bestTarget;
    }

}
