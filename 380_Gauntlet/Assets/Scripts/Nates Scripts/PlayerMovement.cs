using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private float speed = 0f;
    public PlayerSO BasePlayer;
   
    public float playerHealth = 100; 
   
    private Vector3 moveInput = Vector3.zero;
    private Vector3 move = Vector3.zero;
    //private bool throwWeapon = false;
   // private Vector3 throwDistance = new Vector3(1, 0, 0);
    private CharacterController controller;
    private PlayerInput inputs;
   // public GameObject weapon;
    public GameObject ThrowingStick;
    // public GameObject Camera; 

    public bool ToggleInvisibility = false;
    public bool hasKey;
    public bool isMoving = true;
    public bool isThrowing = false;

  



    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
        inputs = this.GetComponent<PlayerInput>();
        speed = BasePlayer.baseSpeed;
       
        // weapon = transform.Find("Stick").gameObject;
        // weapon.SetActive(false);
       
    }

    private void FixedUpdate()
    {
      
        if (isMoving)
        {
            move = new Vector3(moveInput.x * speed, 0, moveInput.y * speed);
            controller.Move(move * speed * Time.deltaTime);
            if (move.magnitude > 0)
            {
                transform.rotation = Quaternion.LookRotation(move);
            }
        }
       // Camera.transform.position = this.transform.position;     
    }


    public void Moving(InputAction.CallbackContext context)
    {
       // moveInput = context.ReadValue<Vector3>();
        if (!isThrowing)
        {
            moveInput = context.ReadValue<Vector3>();
        }
        
    }


    //Logic for proper player movement
    
  public void Stop(InputAction.CallbackContext _up)
  {
        moveInput = Vector2.zero;
       
    }
        


    public void Throwing(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(firingPause());
            GameObject obj = Instantiate(ThrowingStick, this.transform.position, transform.rotation);

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

   
    private IEnumerator Potion()
    {
     
        //Potion code...
       yield return new WaitForSeconds(3);
     
    }

    private IEnumerator firingPause()
    {

        isMoving = false;
        yield return new WaitForSeconds(1f);
        isMoving = true;
        
    }


    


}
