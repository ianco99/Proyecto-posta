﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KevinMOv : MonoBehaviour
{
    CharacterController controller;
    public float speed = 6f;
    public GameObject Fin;
    Vector3 moveDir;
    Vector3 direction;
    float turnSmoothVelocity = 0.1f;
    float turnSmoothTime = 0.1f;
    public Transform cam;
    bool move = false;
    public float velocity;
    float percent;
    float movX;
    float movZ;
    int estadoMov = 1;


    Animator anim; 
    // Start is called before the first frame update
    void Start()
    {
       // MoveToThisPoint(new Vector3(Fin.transform.position.x, Fin.transform.position.y, Fin.transform.position.z));
        anim = this.GetComponent<Animator>();
    }

    void Update(){
        percent = velocity + (0.1f * velocity);
        if (move){
            anim.SetBool("Idle", false);
            float z = direction.z - transform.position.z;
            float x = direction.x - transform.position.x;
           // Debug.Log("x: " + x + ", z:" + z);
            if( estadoMov == 1){
                Debug.Log("Cambiando");
                anim.SetBool("MovingX", true);
                anim.SetBool("MovingZ", false);
                movX = 0;
                if (z >= -percent && z <= percent){
                    movZ = 0; 
                    estadoMov = 2;
                }
                if(z > percent){
                    movZ = velocity;
                    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, -0.831433f);
                }
                if(z < -percent){
                    movZ = -velocity;
                    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 0.831433f);
                }
                Debug.Log("z: " + z);
            }
            if(estadoMov == 2){
                anim.SetBool("MovingZ", true);
                anim.SetBool("MovingX", false);
                movZ = 0;
                if(x >= percent) movX = 0;
                if(x > -percent){
                  movX = velocity;
                  transform.localScale = new Vector3(0.8314339f, transform.localScale.y, transform.localScale.z);
                }
                if (x < percent) {
                    movX = -velocity;
                    transform.localScale = new Vector3(-0.8314339f, transform.localScale.y, transform.localScale.z);
                }
            }
            if(z <= 0.5f && x <= 0.5f && z>= -0.5f && x >= -0.5f){
                move = false;
                anim.SetBool("MovingZ", false);
                anim.SetBool("MovingX", false);
                anim.SetBool("Idle", true);
            }
            transform.Translate(movX,0,movZ);
            Debug.Log("adentro");
        }
    }

    public void MoveToThisPoint(Vector3 vec /*float tiempo*/){
        estadoMov = 1;
        move = true;
        direction = vec; 
        /*direction = transform.position - vec; 
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        moveDir = Quaternion.Euler(0f,targetAngle, 0f) * Vector3.forward;
        moveDir.y = 0;
        controller.Move(moveDir * speed * Time.deltaTime);
        */
    }

    public IEnumerator points(Vector3[] vectors){
        foreach (Vector3 v in vectors){
        Debug.Log(v);
            MoveToThisPoint(v);
            yield return new WaitUntil(() => !move);
        } 
    }
}
