using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyScriptableObject", menuName = "Scriptable Objects/ EnemySO")]
public class EnemyScriptableObject : ScriptableObject
{
    public int damage;

    public float health;
    public float speed;
    public float minAttackRange;
    public float maxAttackRange;

    [Tooltip("Check this to make enemy stop when in range of enemy and run to range if not")]
    public bool isCoward;
    [Tooltip("Check this to make the enemy repeatedly become invisible and invulnerable")]
    public bool canBlink;
    [Tooltip("Checking this makes the enemy disable on collision")]
    public bool isSuicidal;
}
