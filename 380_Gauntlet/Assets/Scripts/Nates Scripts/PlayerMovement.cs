using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float rotateSpeed = 90.0f;
    
   
    private Vector2 moveInput = Vector2.zero;

    //private bool throwWeapon = false;
   // private Vector3 throwDistance = new Vector3(1, 0, 0);
    private CharacterController controller;
    private PlayerInput inputs;
   // public GameObject weapon;
    public GameObject ThrowingStick;
    // public GameObject Camera; 

    public bool ToggleInvisibility = false;
    public bool hasKey;

    private bool turnFirst = false;

    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
        inputs = this.GetComponent<PlayerInput>();

       // weapon = transform.Find("Stick").gameObject;
       // weapon.SetActive(false);
      
    }

    private void FixedUpdate()
    {
       // Camera.transform.position = this.transform.position;
         Vector3 move = new Vector3(moveInput.x * speed, 0, moveInput.y * speed);
         controller.Move(move * speed * Time.deltaTime);
        
    }


    public void Moving(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
       
    }


    //Logic for proper player movement
    
  public void MoveUp(InputAction.CallbackContext _up)
  {
          //   moveInput = _up.ReadValue<Vector2>();
           //  float CurrentDirection = _up.ReadValue<float>();
           //  transform.Rotate(0f, CurrentDirection * rotateSpeed, 0f);
          }
        


    public void Throwing(InputAction.CallbackContext context)
    {
       // throwWeapon = context.ReadValue<bool>();
        //throwWeapon = context.action.triggered;
       // Instantiate(ThrowingStick, this.transform.position, transform.rotation);
        // ThrowingStick.transform.position += transform.forward;
        // Debug.Log("Player Should Throw");
        if (context.performed)
        {
            Instantiate(ThrowingStick, this.transform.position, transform.rotation);
        }
        if (context.canceled)
        {
            return;
        }
    }

   
    public void Melee(InputAction.CallbackContext context)
    {
       // StartCoroutine(MeleeSpeed());
       // Debug.Log("Player Should Melee");
    }

    public void Rotate(InputAction.CallbackContext context)
    {
        float CurrentDirection = context.ReadValue<float>();
        // transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * CurrentDirection);
        transform.Rotate(0f, CurrentDirection * rotateSpeed, 0f);

       // Debug.Log("Player Should Rotate");
    }

    private IEnumerator Potion()
    {
     
        //Potion code...
       yield return new WaitForSeconds(3);
     
    }

}
