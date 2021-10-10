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
        //percent = velocity + (0.1f * velocity);
        percent = 0.1f * velocity;
        if (move){
            anim.SetBool("Idle", false);
            float z = direction.z - transform.position.z;
            float x = direction.x - transform.position.x;
            //Debug.Log("x: " + x + ", z:" + z);
            if(estadoMov == 1){
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
                    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, -0.831433f);
                }
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
            if(z <= percent && x <= percent && z>= -percent && x >= -percent){
                move = false;
                anim.SetBool("MovingZ", false);
                anim.SetBool("MovingX", false);
                anim.SetBool("Idle", true);
                movX = 0;
                Debug.Log("finish");
            }
            transform.Translate(movX * Time.deltaTime, 0,movZ * Time.deltaTime);
            
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
        //Debug.Log(v);
            MoveToThisPoint(v);
            yield return new WaitUntil(() => !move);
        } 
    }

    public void StartDialogueEsp(){
        read.StartDialogue(File, lineaCodPrinc[arrnum], lineaCodFin[arrnum], true);
    }
}
