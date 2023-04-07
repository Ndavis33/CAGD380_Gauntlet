using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
   
    private float speed = 5.0f;

   
    private Vector2 moveInput = Vector2.zero;
    private bool throwWeapon = false;
    public Rigidbody playerRb;
    private CharacterController controller;
    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(moveInput.x * speed, 0, moveInput.y * speed);
        controller.Move(move * speed * Time.deltaTime);
    }


    public void Moving(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
      
    }


    public void Throwing(InputAction.CallbackContext context)
    {
        throwWeapon = context.ReadValue<bool>();
        throwWeapon = context.action.triggered;
        Debug.Log("Player Should Throw");
    }
}
