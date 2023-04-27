using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAttack : MonoBehaviour, IAttackBehavior
{
    public void Attack(EnemyMovement attacker, GameObject target)
    {
        //throw new System.NotImplementedException();
        StartCoroutine(SapHealth());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SapHealth()
    {
        //TODO
        return null;
    }
}
