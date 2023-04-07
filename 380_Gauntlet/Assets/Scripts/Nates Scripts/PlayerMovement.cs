using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
   
    private float speed = 5.0f;
    private float rotateSpeed = 5.0f;

   
    private Vector2 moveInput = Vector2.zero;
    private bool throwWeapon = false;
  
    private CharacterController controller;
    private PlayerInput inputs;
    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
        inputs = this.GetComponent<PlayerInput>();
        
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

    public void Rotate(InputAction.CallbackContext context)
    {
        float CurrentDirection = context.ReadValue<float>();
        // transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * CurrentDirection);
        transform.Rotate(0f, CurrentDirection * 15, 0f);

        Debug.Log("Player Should Rotate");
    }
}
