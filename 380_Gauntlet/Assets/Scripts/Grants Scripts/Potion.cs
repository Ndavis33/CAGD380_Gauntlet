using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField]
    private float range;
    public static int numPotions;

    void OnTriggerEnter(Collider other)
    {
        // Check if the player has collided with the potion object
        if (other.CompareTag("Player"))
        {
            numPotions++;
            this.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X) && numPotions > 0)
        {
            ClearEnemies();
            numPotions--;
        }
    }

    private void ClearEnemies()
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

}
