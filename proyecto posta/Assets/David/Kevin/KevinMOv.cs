using System.Collections;
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
        if(move){
            float z = direction.z - transform.position.z;
            float x = direction.x - transform.position.x;
            if( estadoMov == 1){
                anim.SetBool("walkfront", true);
                anim.SetBool("walkside", false);
                if(z >= 0.25f){
                    movZ = 0; 
                    estadoMov = 2;
                }
                if(z > -0.25f){
                    movZ = 0.25f;
                    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, -0.831433f);
                    anim.SetBool("walkFoB", true);
                }
                if(z < 0.25f){
                    movZ = -0.25f;
                    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 0.831433f);
                    anim.SetBool("walkFoB", false);
                }
            }
            if(estadoMov == 2){
                anim.SetBool("walkfront", false);
                anim.SetBool("walkside", true);
                movZ = 0;
                if(x >= 0.25f) movX = 0;
                if(x > -0.25f){
                  movX = 0.25f;
                  transform.localScale = new Vector3(0.8314339f, transform.localScale.y, transform.localScale.z);
                }
                if(x < 0.25f) {
                    movX = -0.25f;
                    transform.localScale = new Vector3(-0.8314339f, transform.localScale.y, transform.localScale.z);
                }
            }
            if(z <= 0.3f && x <= 0.3f && z>= -0.3f && x >= -0.3f){
                move = false;
                anim.SetBool("walkfront", false);
                anim.SetBool("walkside", false);
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
}
