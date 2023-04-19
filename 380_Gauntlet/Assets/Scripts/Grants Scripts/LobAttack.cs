using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobAttack : MonoBehaviour, IAttackBehavior
{
    public void Attack(EnemyMovement attacker, GameObject target)
    {
        StartCoroutine(Lob(attacker, target));
        //throw new System.NotImplementedException();
    }

    private IEnumerator Lob(EnemyMovement attacker, GameObject target)
    {
        return null;
    }
}
