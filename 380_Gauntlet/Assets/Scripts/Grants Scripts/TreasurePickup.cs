using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasurePickup : MonoBehaviour
{
    [SerializeField]
    public int _value;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           // PlayerMovement.playerScore += _value;
            gameObject.SetActive(false);
        }
    }
}
