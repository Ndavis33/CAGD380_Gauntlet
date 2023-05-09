using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAttack : MonoBehaviour, IAttackBehavior
{
    public void Attack(EnemyMovement attacker, PlayerMovement target)
    {
        //throw new System.NotImplementedException();
        KamikazeGhost(attacker, target);
    }

    private void KamikazeGhost(EnemyMovement attacker, PlayerMovement target)
    {
        target.playerHealth -= attacker.enemySO.damage;
        if (target.playerHealth <= 0)
            target.gameObject.SetActive(false);

        Debug.Log("Player Health: " + target.playerHealth);
        attacker.gameObject.SetActive(false);
    }
}
