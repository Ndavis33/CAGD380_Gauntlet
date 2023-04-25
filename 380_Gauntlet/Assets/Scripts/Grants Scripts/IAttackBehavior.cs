using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackBehavior
{
    //will change from GameObject target to PlayerMovement target after script is finished
    void Attack(EnemyMovement attacker, GameObject target);
}
