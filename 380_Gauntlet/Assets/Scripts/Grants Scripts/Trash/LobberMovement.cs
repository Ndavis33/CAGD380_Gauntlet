using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobberMovement : EnemyMovement
{
    /* Trashed Class
     * 
    private float minAttackRange = 14f;
    private float maxAttackRange = 20f;
    [SerializeField]
    //private float attackRate;
    //public GameObject itemToLob;

    protected override void FixedUpdate()
    {
        float minDistanceFromTarget = 420.69f;
        foreach (TestMovement target in _targets)
        {
            if (Vector3.Distance(this.transform.position, target.transform.position) < minDistanceFromTarget)
            {
                if (target.gameObject.activeInHierarchy)
                {
                    minDistanceFromTarget = Vector3.Distance(this.transform.position, target.transform.position);
                    closestTarget = target.gameObject;
                }
            }
        }

        Debug.Log("Closest Target: " + closestTarget.name);
        targetPos = closestTarget.transform.position;

        if (Vector3.Distance(this.transform.position, targetPos) > maxAttackRange)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime);
        }
        else if (Vector3.Distance(this.transform.position, targetPos) < minAttackRange)
        {
            RunAway();
            Debug.Log("Running");
        }
        else
        {
            if (!attackingPlayer)
            {
                attackingPlayer = true;
                LobObject();
                Debug.Log("Lobbing");
            }
        }
    }

    private void LobObject()
    {
        //TODO
    }

    private void RunAway()
    {
        //TODO
    }
    */
}
