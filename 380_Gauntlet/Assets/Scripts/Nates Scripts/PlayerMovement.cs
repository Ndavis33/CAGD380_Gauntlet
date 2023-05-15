using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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

    public int CurrentKeys = 0;

    public Text _Player1health;
    public Text _Player2health;
    public Text _Player3health;
    public Text _Player4health;

    public static int playerScore;

    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
        inputs = this.GetComponent<PlayerInput>();
        speed = BasePlayer.baseSpeed;
        updateHealth();
        playerScore = 0;
        // weapon = transform.Find("Stick").gameObject;
        // weapon.SetActive(false);
       
    }

    public void KillPlayer()
    {
        Debug.Log("Kill Player");
        StartCoroutine(killRoutine());
    }

    IEnumerator killRoutine()
    {
        yield return new WaitForEndOfFrame();
        transform.GetChild(0).parent = null;
        gameObject.SetActive(false);
    }

  public void updateHealth()
    {

        if (this.gameObject.name == "Warrior Variant")
        {
            _Player1health.text = "Player 1 Health:" + playerHealth.ToString();
        }
        if (this.gameObject.name == "Valkyrie Variant")
        {
            _Player2health.text = "Player 2 Health:" + playerHealth.ToString();
        }
        if (this.gameObject.name == "Wizard Variant")
        {
            _Player3health.text = "Player 3 Health:" + playerHealth.ToString();
        }
        if (this.gameObject.name == "Elf Variant")
        {
            _Player4health.text = "Player 4 Health:" + playerHealth.ToString();
        }
    }

    private void FixedUpdate()
    {
        

        if (isMoving)
        {
            move = new Vector3(moveInput.x * speed, 0, moveInput.y * speed);
            //controller.Move(move * speed * Time.deltaTime);
            transform.Translate(move * Time.deltaTime, Space.World);

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
        isThrowing = true;
        isMoving = false;
        yield return new WaitForSeconds(1f);
        isMoving = true;
        isThrowing = false;

    }


   

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            CurrentKeys++;
            other.gameObject.SetActive(false);
        }
       
    }

    public void OnCollisionEnter(Collision collision)
    {

      
        //Debug.Log("hit obj");
        if (collision.gameObject.tag == "Door")
        {
            Debug.Log("hit Door");
            if (CurrentKeys >= 1)
            {
                collision.gameObject.SetActive(false);
                CurrentKeys--;
            }
        }

        if (collision.gameObject.tag == "Level1")
        {
            if (true)
            {
                //Create Teleporting Script
                Debug.Log("Load Leve2");
                transform.position = ExitCode.FindObjectOfType<ExitCode>().Level2.position;
            }
        }
        if (collision.gameObject.tag == "Level2")
        {
            if (true)
            {
                transform.position = ExitCode.FindObjectOfType<ExitCode>().Level3.position;
                Debug.Log("Load Level 3");
            }
        }
        if (collision.gameObject.tag == "Level3")
        {
            if (true)
            {
                transform.position = ExitCode.FindObjectOfType<ExitCode>().Level1.position;
                Debug.Log("Load Level 0");
            }
        }


    }


}
