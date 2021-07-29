﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Transform cam;
    [SerializeField] Animator anim;

    public float speed = 6f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float tiempoFlota;


    [SerializeField] bool jumping = false;
    [SerializeField] bool puedeFlotar;

    float horizontal;
    float vertical;
    public Vector3 direction;
    Vector3 moveDir;
    float directionY;

    [SerializeField] float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    private float gravity = 9.81f;


    [SerializeField] float raycastDistance;
    public bool interacting = false;
    [SerializeField] GameObject interacted;
    [SerializeField] Transform raycastOrigin;

    public float pushPower = 2.0f;

    public bool isOnSplope = false;
    private Vector3 hitNormal;
    public float slideVelocity;

    [SerializeField] GameObject puller;

    private void Update(){

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0f, vertical).normalized; //Getting our inputs in the vector3 direction
        Move();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("Mecanicas");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("Biblioteca");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.instance.UpdateGameState(GameState.Menu);
        }
        Animations();


    }


    void Move(){
        if (controller.isGrounded){
            jumping = false;
            puedeFlotar = true;

            if(Input.GetKeyDown(KeyCode.Space)){
                directionY = jumpSpeed;
                jumping = true;
            } 
        }
        else{
            directionY -= gravity * Time.deltaTime; //Applying gravity to direction on the Y axis times Time.deltaTime

            if(Input.GetKeyUp(KeyCode.Space)){
                jumping = false;
            }
                if (Input.GetKey(KeyCode.Space) && controller.isGrounded == false && jumping == false && puedeFlotar){
                    StartCoroutine("Flotar");
                }
        }

        SlideDown();

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDir = Quaternion.Euler(0f,targetAngle, 0f) * Vector3.forward;
            moveDir.y = directionY;
            controller.Move(moveDir * speed * Time.deltaTime);
        }   
        else{
            direction.y = directionY;
            controller.Move(direction * speed * Time.deltaTime);            
        }
        
    }

    void Animations()
    {
        anim.SetFloat("velocidadX", horizontal);
        anim.SetFloat("velocidadZ", vertical);
        
        if(direction.x == 0 && direction.y == 0 && direction.z == 0){
            anim.SetBool("Idle", true);
        }
        else{
            anim.SetBool("Idle", false);
        }

    }
    IEnumerator Flotar () {
        puedeFlotar = false;
        float elapsed = 0f;
        while (elapsed < tiempoFlota && Input.GetKey(KeyCode.Space))
        {
        directionY = 0f;
        elapsed += Time.deltaTime;
        yield return new WaitForEndOfFrame();
        }
    }

    public void SlideDown()
    {
        isOnSplope = Vector3.Angle(Vector3.up, hitNormal) >= controller.slopeLimit;
        
        if(isOnSplope)
        {
            moveDir.x += hitNormal.x * slideVelocity;
            moveDir.z += hitNormal.z * slideVelocity;
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitNormal = hit.normal;

    }
}