using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAttack : MonoBehaviour, IAttackBehavior
{
    //private EnemyScriptableObject _enemySO;
    private float _maxHealthSap = 200f;
    private float _startSpeed, _speed;

    private int _healthSapped;

    private bool _sapping = false;

    public void Attack(EnemyMovement attacker, PlayerMovement target)
    {
        //throw new System.NotImplementedException();
        //attacker.GetComponent<Collider>().isTrigger = true;
        StartCoroutine(SapHealth(attacker, target));
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        _healthSapped = 0;
        _startSpeed = this.GetComponent<EnemyMovement>().enemySO.speed;
    }

    private void OnDisable()
    {
        this.GetComponent<EnemyMovement>().enemySO.speed = _startSpeed;
    }

    private IEnumerator SapHealth(EnemyMovement attacker, PlayerMovement target)
    {
        while (_healthSapped < _maxHealthSap)
        {
            if (attacker.attackingPlayer && target.isActiveAndEnabled)
            {
                //temp action until player death is handled
                if (target.playerHealth <= 0)
                    target.gameObject.SetActive(false);

                attacker.enemySO.speed = 0;
                target.playerHealth -= attacker.enemySO.damage;
                _healthSapped += attacker.enemySO.damage;
                Debug.Log("Target Health: " + target.playerHealth);
                Debug.Log("Sapped Health: " + _healthSapped);

                if (_healthSapped >= _maxHealthSap)
                {
                    this.gameObject.SetActive(false);
                    Debug.Log("Sapped max health");
                    break;
                }


            }
            else
            {
                Debug.Log("Not attacking player");
                break;
            }


            yield return new WaitForSeconds(attacker.enemySO.attackRate);


        }

        attacker.enemySO.speed = _startSpeed;
    }

    //need to incorporate this event after we make potions
    private void OnPotionUsed()
    {
        this.gameObject.SetActive(false);
    }
}
