using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMeleeAttack : MonoBehaviour, IAttackBehavior
{
    private EnemyScriptableObject _enemySO;
    private PlayerMovement _player;
    private float _startSpeed;

    private void Awake()
    {
        _enemySO = this.GetComponent<EnemyMovement>().enemySO;
        _startSpeed = _enemySO.speed;
    }
    public void Attack(EnemyMovement attacker, PlayerMovement target)
    {
        _player = target.GetComponent<PlayerMovement>();
        StartCoroutine(MeleePlayer(target, attacker));
        //throw new System.NotImplementedException();
    }

    private IEnumerator MeleePlayer(PlayerMovement player, EnemyMovement enemy)
    {
        //example player stats for testing
        _enemySO.damage = 25;
       
        if (enemy.attackingPlayer)
        {
            while (_player.playerHealth > 0)
            {
                Debug.Log("Attacking player");
                _player.playerHealth -= _enemySO.damage;

                if (_player.playerHealth <= 0)
                {
                    player.gameObject.SetActive(false);
                    Debug.Log("Target eliminated");
                    break;
                }

                _enemySO.speed = 0;
                yield return new WaitForSeconds(_enemySO.attackRate);
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
