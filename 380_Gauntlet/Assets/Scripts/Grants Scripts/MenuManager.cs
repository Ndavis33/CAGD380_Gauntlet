using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    public Material redMat, blueMat, yellowMat, greenMat; 
    public GameObject avatar1, avatar2, avatar3, avatar4;
   
    public Text avatar1Text, avatar2Text, avatar3Text, avatar4Text;
    public Button p1Forward, p1Back, p2Forward, p2Back, p3Forward, p3Back, p4Forward, p4Back, playButton;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public Transform player1Spawn;
    public Transform player2Spawn;
    public Transform player3Spawn;
    public Transform player4Spawn;

 
    public Camera mainCamera;
    public Camera Cam_1;
    public Camera Cam_2;
    public Camera Cam_3;
    public Camera Cam_4;
    public GameObject MainMenu;
    
   public int ControllerNumber;

    private Color _red;
    private Color _blue;
    private Color _yellow;
    private Color _green;
    private bool p1Locked, p2Locked, p3Locked, p4Locked = false;


  
    private void Awake()
    {
        _red = redMat.color;
        _blue = blueMat.color;
        _yellow = yellowMat.color;
        _green = greenMat.color;

        avatar1.GetComponent<PlayerMovement>().enabled = false;
       


        avatar2.GetComponent<PlayerMovement>().enabled = false;
        avatar3.GetComponent<PlayerMovement>().enabled = false;
        avatar4.GetComponent<PlayerMovement>().enabled = false;
            
          
            // avatar1 = Warrior;
        //  avatar2 = Valkyrie;
       //   avatar3 = Wizard;
      //   avatar4 = Elf;

        //    Warrior.gameObject.SetActive(false);
        //   Valkyrie.gameObject.SetActive(false);
        //   Elf.gameObject.SetActive(false);
        //   Wizard.gameObject.SetActive(false);
     
       playButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        
        ControllerNumber = Gamepad.all.Count;

        
        if (ControllerNumber < 1)
        {
            player1.gameObject.SetActive(true);
        }
        if (ControllerNumber <2)
        {
            player2.gameObject.SetActive(true);
        }
        if (ControllerNumber < 3)
        {
            player3.gameObject.SetActive(true);
        }
        if (ControllerNumber < 4)
        {
            player4.gameObject.SetActive(true);
        }
        


        
        if (p1Locked && p2Locked && p3Locked && p4Locked)
        {
            playButton.gameObject.SetActive(true);
        }
        else
            playButton.gameObject.SetActive(false);
        
    }



  


   


    public void SplitScreen()
    {
        // GameObject player1 = Instantiate(avatar1, player1Spawn, Quaternion.identity);
        avatar1.GetComponent<PlayerMovement>().enabled = true;
        avatar2.GetComponent<PlayerMovement>().enabled = true;
        avatar3.GetComponent<PlayerMovement>().enabled = true;
        avatar4.GetComponent<PlayerMovement>().enabled = true;

        mainCamera.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(false);

    }



    /// <summary>
    /// Grants Code
    /// </summary>
    public void p1Lock()
    {
       // Warrior.gameObject.SetActive(true);
        if (!p1Locked)
        {
            if (!CheckContested(avatar1Text))
            {
                p1Forward.gameObject.SetActive(false);
                p1Back.gameObject.SetActive(false);
                p1Locked = true;
                // Instantiate(avatar1, player1Spawn.position, Quaternion.identity);
                // GameObject _Player1 = GameObject.Find("Warrior Variant(Clone)");
                //  _Player1.transform.Find("Camera").gameObject.SetActive(true);
                avatar1.transform.position = player1Spawn.position;
              
            }
        }
        else
        {
            p1Forward.gameObject.SetActive(true);
            p1Back.gameObject.SetActive(true);
            p1Locked = false;
        }

    }

    public void p2Lock()
    {
       // Valkyrie.gameObject.SetActive(true);
        if (!p2Locked)
        {
            if (!CheckContested(avatar2Text))
            {
                p2Forward.gameObject.SetActive(false);
                p2Back.gameObject.SetActive(false);
                p2Locked = true;
                avatar2.transform.position = player2Spawn.position;
            }
        }
        else
        {
            p2Forward.gameObject.SetActive(true);
            p2Back.gameObject.SetActive(true);
            p2Locked = false;
        }

    }

    public void p3Lock()
    {
       // Wizard.gameObject.SetActive(true);
        if (!p3Locked)
        {
            if (!CheckContested(avatar3Text))
            {
                p3Forward.gameObject.SetActive(false);
                p3Back.gameObject.SetActive(false);
                p3Locked = true;
                avatar3.transform.position = player3Spawn.position;
            }
        }
        else
        {
            p3Forward.gameObject.SetActive(true);
            p3Back.gameObject.SetActive(true);
            p3Locked = false;
        }

    }

    public void p4Lock()
    {
       //  Elf.gameObject.SetActive(true);
        if (!p4Locked)
        {
            if (!CheckContested(avatar4Text))
            {
                p4Forward.gameObject.SetActive(false);
                p4Back.gameObject.SetActive(false);
                p4Locked = true;
                avatar4.transform.position = player4Spawn.position;
            }
        }
        else
        {
            p4Forward.gameObject.SetActive(true);
            p4Back.gameObject.SetActive(true);
            p4Locked = false;
        }

    }

    private bool CheckContested(Text playerType)
    {
        int numSame = 0;

        if (playerType.text == avatar1Text.text)
            numSame++;
        if (playerType.text == avatar2Text.text)
            numSame++;
        if (playerType.text == avatar3Text.text)
            numSame++;
        if (playerType.text == avatar4Text.text)
            numSame++;

        //Debug.Log("Contested types: " + numSame);

        if (numSame <= 1)
            return false;
        else return true;
    }

    private Color NextMat(GameObject avatar)
    {
        Color avatarMat = avatar.GetComponent<Renderer>().material.color;

        if (avatarMat == _red)
        {
            return _blue;
        }
            
        else if (avatarMat == _blue)
        {
            return _yellow;
        }
            
        else if (avatarMat == _yellow)
            return _green;
        else return _red;       
    }

    private Color LastMat(GameObject avatar)
    {
        Color avatarMat = avatar.GetComponent<Renderer>().material.color;

        if (avatarMat == _red)
            return _green;    
        else if (avatarMat == _blue)
            return _red;
        else if (avatarMat == _yellow)
            return _blue;
        else return _yellow;
    }

    private string GetPlayerType(Color avatarColor)
    {
        if (avatarColor == _red)
            return "Warrior";
        else if (avatarColor == _blue)
            return "Valkyrie";
        else if (avatarColor == _yellow)
            return "Wizard";
        else return "Elf";
    }

    public void Player1Forward()
    {
        Color avatarColor;
        avatarColor = NextMat(avatar1);
        avatar1.GetComponent<Renderer>().material.color = avatarColor;
        avatar1Text.text = GetPlayerType(avatarColor);

    }

    public void Player1Backward()
    {
        Color avatarColor;
        avatarColor = LastMat(avatar1);
        avatar1.GetComponent<Renderer>().material.color = avatarColor;
        avatar1Text.text = GetPlayerType(avatarColor);
    }

    public void Player2Forward()
    {
        Color avatarColor;
        avatarColor = NextMat(avatar2);
        avatar2.GetComponent<Renderer>().material.color = avatarColor;
        avatar2Text.text = GetPlayerType(avatarColor);
    }

    public void Player2Backward()
    {
        Color avatarColor;
        avatarColor = LastMat(avatar2);
        avatar2.GetComponent<Renderer>().material.color = avatarColor;
        avatar2Text.text = GetPlayerType(avatarColor);
    }

    public void Player3Forward()
    {
        Color avatarColor;
        avatarColor = NextMat(avatar3);
        avatar3.GetComponent<Renderer>().material.color = avatarColor;
        avatar3Text.text = GetPlayerType(avatarColor);
    }

    public void Player3Backward()
    {
        Color avatarColor;
        avatarColor = LastMat(avatar3);
        avatar3.GetComponent<Renderer>().material.color = avatarColor;
        avatar3Text.text = GetPlayerType(avatarColor);
    }

    public void Player4Forward()
    {
        Color avatarColor;
        avatarColor = NextMat(avatar4);
        avatar4.GetComponent<Renderer>().material.color = avatarColor;
        avatar4Text.text = GetPlayerType(avatarColor);
    }

    public void Player4Backward()
    {
        Color avatarColor;
        avatarColor = LastMat(avatar4);
        avatar4.GetComponent<Renderer>().material.color = avatarColor;
        avatar4Text.text = GetPlayerType(avatarColor);
    }
}
