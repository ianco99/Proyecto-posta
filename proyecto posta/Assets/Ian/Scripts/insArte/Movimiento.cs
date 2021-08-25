using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] float horizontalMove;
    [SerializeField] float verticalMove;
    private Vector3 playerInput;

    public CharacterController player;

    public float playerSpeed;
    private void Start()
    {
        player = GetComponent<CharacterController>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        player.Move(new Vector3(horizontalMove, 0, verticalMove) * playerSpeed * Time.deltaTime);

        
    }

    
}