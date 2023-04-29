using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] characters;
    public Camera[] cameras;
    public GameObject playerPrefab;
    public Transform[] spawnPoints;

    private List<PlayerInput> players = new List<PlayerInput>();

    private bool SelectPlayer = false;
    private int NumPlayers = 0;


  public void PressXtoStart(InputAction.CallbackContext context)
    {

    }
}
