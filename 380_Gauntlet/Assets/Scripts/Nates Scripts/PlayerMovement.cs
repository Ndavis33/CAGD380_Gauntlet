using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float rotateSpeed = 15.0f;

   
    private Vector2 moveInput = Vector2.zero;

    private bool throwWeapon = false;
  
    private CharacterController controller;
    private PlayerInput inputs;
    public GameObject weapon;
    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
        inputs = this.GetComponent<PlayerInput>();
        weapon = transform.Find("Stick").gameObject;
        weapon.SetActive(false);
      
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

    public void Melee(InputAction.CallbackContext context)
    {
        StartCoroutine(MeleeSpeed());
        Debug.Log("Player Should Melee");
    }

    public void Rotate(InputAction.CallbackContext context)
    {
        float CurrentDirection = context.ReadValue<float>();
        // transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * CurrentDirection);
        transform.Rotate(0f, CurrentDirection * rotateSpeed, 0f);

        Debug.Log("Player Should Rotate");
    }

    private IEnumerator MeleeSpeed()
    {
      weapon.SetActive(true);
       yield return new WaitForSeconds(0.25f);
      weapon.SetActive(false);
    }

}
