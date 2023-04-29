using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAttack : MonoBehaviour, IAttackBehavior
{
    //private EnemyScriptableObject _enemySO;
    private float _maxHealthSap = 200f;

    private int _healthSapped;

    private bool _sapping = false;

    public void Attack(EnemyMovement attacker, PlayerMovement target)
    {
        //throw new System.NotImplementedException();
        StartCoroutine(SapHealth(attacker, target));
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        _healthSapped = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SapHealth(EnemyMovement attacker, PlayerMovement target)
    {
        while (_healthSapped < _maxHealthSap)
        {
            if (_sapping)
            {
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
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            _sapping = true;
        }
    }
}
