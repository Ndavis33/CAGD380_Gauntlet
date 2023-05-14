using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasurePickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //PlayerMovement needs a score variable first
            //other.gameObject.GetComponent<PlayerMovement>().playerScore += 100;
            gameObject.SetActive(false);
        }
    }
}
