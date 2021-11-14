using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KevinMOv : MonoBehaviour
{
    CharacterController controller;
    public float speed = 0.01f;
    Vector3 moveDir;
    Vector3 direction;
    float turnSmoothVelocity = 0.1f;
    float turnSmoothTime = 0.1f;
    public Transform cam;
    bool move = false;
    public float velocity;
    public float percent;
    public float movX;
    public float movZ;
    int estadoMov = 1;
    public bool NPC;
    public Animator anim; 
    public ReadTxt read;
    public int[] lineaCodPrinc;
    public int[] lineaCodFin;
    public string File;
    private int arrnum;
    float horizontal;
    bool conversionX = true;
    bool conversionZ = true;
    bool doEvent = false;
    NavMeshAgent agente;

    public void sumArrnum(){
        arrnum++;
    }

    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        GameObject obj = GameObject.FindGameObjectWithTag("Text");
        read = obj.GetComponent<ReadTxt>();
        agente.updateRotation = false;
       // MoveToThisPoint(new Vector3(Fin.transform.position.x, Fin.transform.position.y, Fin.transform.position.z));
       // anim = this.GetComponent<Animator>();
        //anim.SetInteger("NPC", NPC);
    }

    void FixedUpdate(){
        
        //percent = velocity + (0.1f * velocity);
        percent = 0.5f;
        if (move){
            horizontal = direction.x - transform.position.x;
            anim.SetBool("Idle", false);
            float z = direction.z - transform.position.z;
            float x = direction.x - transform.position.x;
            //Debug.Log("x: " + x + ", z:" + z);
            if(estadoMov == 1){
                agente.enabled = true;
                movX = 0;
                agente.destination = direction;
               /* if(direction.z < transform.position.z)movZ = -velocity * Time.deltaTime;
                else if(direction.z > transform.position.z) movZ = velocity * Time.deltaTime;
                else if (z >= -percent && z <= percent)
                {
                    movZ = 0;
                    estadoMov = 2;
                }
                else movZ = 0;
                
               transform.Translate(0, 0, movZ);*/
                if(z>-0.5f && z<0.5f &&x >-0.5f && x<0.5f) estadoMov = 2;
            }
            if(estadoMov == 2){
                agente.enabled = false;
                move = false;
                movX = 0;
                movZ=0;
                if (doEvent)
                {
                    GameEvents.current.FinishedWalkingToPoint();
                }
                anim.SetBool("Idle", true);
                horizontal = 0f;
            }
           // Debug.Log("z: " +z + ", x: " + x);
            
            
        }
        Animations();
    }

    public void MoveToThisPoint(Vector3 vec, bool sendsEvent /*float tiempo*/){
        estadoMov = 1;
        move = true;
        direction = vec;
        doEvent = sendsEvent;
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
            MoveToThisPoint(v, false);
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
