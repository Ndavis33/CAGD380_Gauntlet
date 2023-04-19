using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMeleeAttack : MonoBehaviour, IAttackBehavior
{
    private EnemyScriptableObject _enemySO;
    private float _startSpeed;

    private void Awake()
    {
        _enemySO = this.GetComponent<EnemyMovement>().enemySO;
        _startSpeed = _enemySO.speed;
    }
    public void Attack(EnemyMovement attacker, GameObject target)
    {
        StartCoroutine(MeleePlayer(target, attacker));
        //throw new System.NotImplementedException();
    }

    private IEnumerator MeleePlayer(GameObject player, EnemyMovement enemy)
    {
        //example player stats for testing
        _enemySO.damage = 25;
        float playerHP = 100;
       
        if (enemy.attackingPlayer)
        {
            while (playerHP > 0)
            {
                Debug.Log("Attacking player");
                playerHP -= _enemySO.damage;
                Debug.Log("Test Player at " + playerHP + "health");

                if (playerHP <= 0)
                {
                    player.gameObject.SetActive(false);
                    Debug.Log("Target eliminated");
                    break;
                }

                _enemySO.speed = 0;
                yield return new WaitForSeconds(1);
                _enemySO.speed = _startSpeed;

                if (!enemy.attackingPlayer)
                    break;

            }

        }

    }

    private void OnDestroy()
    {
        _enemySO.speed = _startSpeed;
    }

}
