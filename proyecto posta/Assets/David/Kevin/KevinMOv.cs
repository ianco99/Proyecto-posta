using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KevinMOv : MonoBehaviour
{
    CharacterController controller;
    public float speed = 6f;
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
    public bool NPC;
    public Animator anim; 
    public ReadTxt read;
    public int[] lineaCodPrinc;
    public int[] lineaCodFin;
    public string File;
    private int arrnum;
    float horizontal;

    public void sumArrnum(){
        arrnum++;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Text");
        read = obj.GetComponent<ReadTxt>();
       // MoveToThisPoint(new Vector3(Fin.transform.position.x, Fin.transform.position.y, Fin.transform.position.z));
       // anim = this.GetComponent<Animator>();
        //anim.SetInteger("NPC", NPC);
    }

    void Update(){
        Debug.Log("Horizontal: " +horizontal);
        //percent = velocity + (0.1f * velocity);
        percent = 0.1f * velocity;
        if (move){
            horizontal = direction.x - transform.position.x;
            anim.SetBool("Idle", false);
            float z = direction.z - transform.position.z;
            float x = direction.x - transform.position.x;
            //Debug.Log("x: " + x + ", z:" + z);
            if(estadoMov == 1){
                
                movX = 0;
                if (z >= -percent && z <= percent){
                    movZ = 0; 
                    estadoMov = 2;
                }
                if(z > percent){
                    movZ = velocity;
                  
                }
                if(z < -percent){
                    movZ = -velocity;
                   
                }
            }
            if(estadoMov == 2){
                movZ = 0;
                if(x >= percent) movX = 0;
                if(x > -percent){
                  movX = velocity;
                }
                if (x < percent) {
                    movX = -velocity;
                }
                
            }
            if(z <= percent && x <= percent && z>= -percent && x >= -percent){
                move = false;
                movX = 0;
                Debug.Log("finish");
                anim.SetBool("Idle", true);
                horizontal = 0f;
                direction = new Vector3(0,0,0);
            }
            transform.Translate(movX * Time.deltaTime, 0,movZ * Time.deltaTime);
            
        }
        Animations();
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
        //Debug.Log(v);
            MoveToThisPoint(v);
            yield return new WaitUntil(() => !move);
        } 
    }

    public void StartDialogueEsp(){
        read.StartDialogue(File, lineaCodPrinc[arrnum], lineaCodFin[arrnum], true);
    }

    public  void Animations(){
        anim.SetFloat("MovingX", horizontal);
        if(horizontal == 0) anim.SetBool("Idle", true);
        else anim.SetBool("Idle", false);
    }
}
