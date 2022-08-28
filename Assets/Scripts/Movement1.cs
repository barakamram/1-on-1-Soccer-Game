using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement1 : MonoBehaviour
{
    private Vector3 moveDirection;
    private CharacterController controller;
    [SerializeField] private float sensitivity;
    [SerializeField] private float moveSpeed;
    private float plusOne = 1f;
    private float minusOne = -1f;
    private float gravity = -10f;
    private Vector3 velocity;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {    
        float rotate = sensitivity * Time.deltaTime;
        moveDirection = new Vector3(0, 0, plusOne);
        moveDirection *= moveSpeed;
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection = transform.TransformDirection(moveDirection);
            controller.Move(moveDirection * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveDirection *= minusOne;
            moveDirection = transform.TransformDirection(moveDirection);
            controller.Move(moveDirection * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)) transform.Rotate(Vector3.up, rotate);
        if (Input.GetKey(KeyCode.A)) transform.Rotate(Vector3.up, -rotate);
        velocity.y += gravity * moveSpeed * Time.deltaTime;
        controller.Move(velocity);
        
    }
}
