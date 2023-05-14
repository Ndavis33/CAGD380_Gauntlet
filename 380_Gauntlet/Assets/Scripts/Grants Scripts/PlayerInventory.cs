using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Allows the player to interact with items in inventory
public class PlayerInventory : MonoBehaviour
{
    /*
    public PlayerInventorySO inventorySO;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X) && inventorySO.numPotions > 0)
        {
            inventorySO.numPotions--;
        }
        else if (Input.GetKeyDown(KeyCode.X) && inventorySO.numPotions <= 0)
        {
            Debug.Log("Out of potions");
        }

    }

    private void UsePotion()
    {
        Camera cam = Camera.main;
        Collider[] hitColliders = Physics.OverlapSphere(cam.transform.position, range);
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.GetComponent<EnemyMovement>())
            {
                hitCollider.gameObject.SetActive(false);
            }
        }
    }
    */
}
