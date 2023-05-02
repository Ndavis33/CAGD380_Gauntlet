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
        attacker.GetComponent<Collider>().isTrigger = true;
        StartCoroutine(SapHealth(attacker, target));
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        _healthSapped = 0;
        _startSpeed = this.GetComponent<EnemyMovement>().enemySO.speed;
        _speed = this.GetComponent<EnemyMovement>().enemySO.speed;
    }

    private void OnDisable()
    {
        this.GetComponent<EnemyMovement>().enemySO.speed = _startSpeed;
    }

    private IEnumerator SapHealth(EnemyMovement attacker, PlayerMovement target)
    {
        while (_healthSapped < _maxHealthSap && attacker.attackingPlayer)
        {
            if (_sapping)
            {
                _speed = 0;
                target.playerHealth -= attacker.enemySO.damage;
                _healthSapped += attacker.enemySO.damage;
                Debug.Log("Target Health: " + target.playerHealth);

                if(_healthSapped >= _maxHealthSap)
                {
                    this.gameObject.SetActive(false);
                    break;
                }


            }
            else
                break;

            yield return new WaitForSeconds(0.25f);
            if (!attacker.attackingPlayer)
            {
                _speed = _startSpeed;
                break;
            }
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _sapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _sapping = false;
        }
    }
}
