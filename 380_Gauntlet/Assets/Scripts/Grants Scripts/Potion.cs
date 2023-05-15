using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField]
    private float range;
    //public PlayerInventorySO inventorySO;
    private GameObject _user;
    public PlayerMovement playerMovement;
 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //inventorySO.numPotions++;
            
            _user = other.gameObject;
           // ClearEnemies();
            this.gameObject.SetActive(false);
        }
    }

    private void ClearEnemies()
    {
        Camera cam = _user.GetComponentInChildren<Camera>();
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
