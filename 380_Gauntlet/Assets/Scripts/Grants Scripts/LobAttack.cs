using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobAttack : MonoBehaviour, IAttackBehavior
{
    public GameObject attackTarget;
    public void Attack(EnemyMovement attacker, GameObject target)
    {
        attackTarget = target;
        StartCoroutine(Lob(attacker));
        //throw new System.NotImplementedException();
    }

    private IEnumerator Lob(EnemyMovement attacker)
    {
        //yield return new WaitForSeconds(1);

        GameObject projectile = ObjectPooler.Instance.GetPooledObject("Lobber Projectile");
        while (attacker.attackingPlayer)
        {
            Debug.Log("attacking player");
            if (projectile != null)
            {
                projectile.transform.position = attacker.transform.position;
                projectile.transform.rotation = attacker.transform.rotation;
                projectile.SetActive(true);
            }
            yield return new WaitForSeconds(3);
        }
        

        attacker.attackingPlayer = false;
    }
}
