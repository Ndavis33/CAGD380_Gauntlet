using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField]
    private float range;
    //public PlayerInventorySO inventorySO;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //inventorySO.numPotions++;
            ClearEnemies();
            this.gameObject.SetActive(false);
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
