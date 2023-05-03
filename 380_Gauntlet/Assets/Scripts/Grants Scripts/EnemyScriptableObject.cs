using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyScriptableObject", menuName = "Scriptable Objects/ EnemySO")]
public class EnemyScriptableObject : ScriptableObject
{
    //public IAttackBehavior strategyToUse;
    public int damage;

    public float health;
    public float speed;
    public float minAttackRange;
    public float maxAttackRange;
    public float attackRate;

    public Color enemyColor;

    public EnemyType enemyType;
}
