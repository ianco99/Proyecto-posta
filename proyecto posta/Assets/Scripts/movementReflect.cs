using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementReflect : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Transform cam;
    [SerializeField] Animator anim;
    [SerializeField] Animator anim2;
    public float intialSpeed = 6f;
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

    public GameObject AudioManager;

    [SerializeField] GameObject puller;

    private void Update()
    {
        anim.SetBool("IsGrounded", controller.isGrounded);
        anim2.SetBool("IsGrounded", controller.isGrounded);
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0f, vertical).normalized; //Getting our inputs in the vector3 direction
        Move();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.instance.UpdateGameState(GameState.Menu);
        }
        Animations();


    }


    void Move()
    {
        if (controller.isGrounded)
        {
            jumping = false;
            puedeFlotar = true;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                directionY = jumpSpeed;
                AudioManager.GetComponent<AudioManager>().Play("Jump");
                jumping = true;
            }
        }
        else
        {
            directionY -= gravity / 1.5f * Time.deltaTime; //Applying gravity to direction on the Y axis times Time.deltaTime

            if (Input.GetKeyUp(KeyCode.Space))
            {
                jumping = false;
            }
            if (Input.GetKey(KeyCode.Space) && controller.isGrounded == false && jumping == false && puedeFlotar)
            {
                StartCoroutine("Flotar");
            }
        }

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            moveDir.y = directionY;
            controller.Move(moveDir * speed * Time.deltaTime);
            SlideDown();
        }
        else
        {
            direction.y = directionY;
            controller.Move(direction * speed * Time.deltaTime);
            SlideDown();
        }
    }

    void Animations()
    {

        anim.SetFloat("velocidadX", horizontal);
        anim.SetFloat("velocidadZ", vertical);
        anim.SetFloat("velocidadY", directionY);
        anim2.SetFloat("velocidadY", directionY);
        anim2.SetFloat("velocidadZ", vertical);
        anim2.SetFloat("velocidadX", horizontal);


        if (horizontal > 0.01f)
        {
            anim.SetBool("FacingRight", true);
            anim.SetBool("Sided", true);
            anim2.SetBool("FacingRight", true);
            anim2.SetBool("Sided", true);
        }
        else if (horizontal < -0.01f)
        {
            anim.SetBool("FacingRight", false);
            anim.SetBool("Sided", true);
            anim2.SetBool("FacingRight", false);
            anim2.SetBool("Sided", true);
        }
        if (vertical > 0.01f && horizontal == 0)
        {
            anim.SetBool("Sided", false);
            anim2.SetBool("Sided", false);
        }
        else if (vertical < -0.01f && horizontal == 0)
        {
            anim.SetBool("Sided", false);
            anim2.SetBool("Sided", false);
        }
        if (horizontal == 0f && vertical == 0)
        {
            anim.SetBool("Sided", true);
            anim2.SetBool("Sided", true);
        }

        if (direction.x == 0 && direction.z == 0)
        {
            anim.SetBool("Idle", true);
            anim2.SetBool("Idle", true);
        }
        else
        {
            anim.SetBool("Idle", false);
            anim2.SetBool("Idle", false);
        }

    }
    IEnumerator Flotar()
    {
        puedeFlotar = false;
        float elapsed = 0f;
        while (elapsed < tiempoFlota && Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("Floating", true);
            anim2.SetBool("Floating", true);
            directionY = 0f;
            elapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        anim.SetBool("Floating", false);
        anim2.SetBool("Floating", false);
    }

    public void SlideDown()
    {
        isOnSplope = Vector3.Angle(Vector3.up, hitNormal) >= controller.slopeLimit;

        if (isOnSplope)
        {
            direction.x += hitNormal.x * slideVelocity;
            direction.z += hitNormal.z * slideVelocity;
            moveDir.x += hitNormal.x * slideVelocity;
            moveDir.z += hitNormal.x * slideVelocity;
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitNormal = hit.normal;

    }
}