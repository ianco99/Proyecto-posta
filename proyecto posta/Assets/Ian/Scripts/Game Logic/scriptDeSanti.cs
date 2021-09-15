using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptDeSanti : MonoBehaviour
{
    Vector3 movement = new Vector3();
    bool move = false;
    [SerializeField] float stepSize = 5f;
    [SerializeField] bool xFirst = true;
    int estadoMov = 1;
    public Animator anim;

    public void MoveToDestination(Vector3 destination)
    {
        movement = destination - transform.position;
        move = true;
        if (xFirst == false || Mathf.Abs(movement.x) < stepSize * Time.deltaTime)
        {
            estadoMov = 2;
        }
    }
    void Update()
    {
        
        if (move == true)
        {
            anim.SetBool("Idle", false);
            if (estadoMov == 1)
            {
                anim.SetBool("MovingX", true);
                anim.SetBool("MovingZ", false);
                float moveStep = (movement.x > 0 ? 1 : -1) * stepSize * Time.deltaTime;
                transform.Translate(new Vector3(moveStep, 0, 0));
                movement.x -= moveStep;
                if (Mathf.Abs(movement.x) < stepSize * Time.deltaTime)
                {
                    estadoMov = 2;
                    if (Mathf.Abs(movement.z) < stepSize * Time.deltaTime)
                    {
                        move = false;
                    }
                    movement.x = 0;
                }

            }
            else
            {
                anim.SetBool("MovingZ", true);
                anim.SetBool("MovingX", false);
                float moveStep = (movement.z > 0 ? 1 : -1) * stepSize * Time.deltaTime;
                transform.Translate(new Vector3(0, 0, moveStep));
                movement.z -= moveStep;
                if (Mathf.Abs(movement.z) < stepSize * Time.deltaTime)
                {
                    estadoMov = 1;
                    if (Mathf.Abs(movement.x) < stepSize * Time.deltaTime)
                    {
                        move = false;
                    }
                    movement.z = 0;
                }
            }
        }
        else
        {
            anim.SetBool("Idle", true);
            anim.SetBool("MovingX", false);
            anim.SetBool("MovingZ", false);
        }
    }
}

