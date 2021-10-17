using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuartoDeKevinDoor : Interactable1
{
    public bool alreadyTalked = false;
    [SerializeField] string descripcion;
    [SerializeField] Transform posPrev;
    [SerializeField] Transform posnext;
    [SerializeField] Transform proxPosFinn;
    bool z = false;

    private void Start()
    {
        posPrev = transform;
    }
    public override string GetDescription()
    {
        return descripcion;
    }

    public override void changeCamera()
    {

    }
    public override void Interact()
    {
        if (!alreadyTalked)
        {
            changePos();
            //GameObject.FindGameObjectWithTag("GameController").GetComponent<timelineController>().Play();
            gameManager.instance.UpdateGameState(GameState.Dialogue);     
            alreadyTalked = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<KevinMOv>().MoveToThisPoint(proxPosFinn.position);
        }
    }

    public void changePos()
    {
        if (!z)
        {
            transform.position = posnext.position;
            transform.rotation = posnext.rotation;
            
        }
        else
        {
            transform.position = posPrev.position;
            transform.rotation = posPrev.rotation;
        }
        z = !z;
    }
}
