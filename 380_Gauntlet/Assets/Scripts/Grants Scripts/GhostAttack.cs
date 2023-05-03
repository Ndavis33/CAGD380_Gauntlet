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
        Debug.Log("Player Health: " + target.playerHealth);
        attacker.gameObject.SetActive(false);
    }
}
