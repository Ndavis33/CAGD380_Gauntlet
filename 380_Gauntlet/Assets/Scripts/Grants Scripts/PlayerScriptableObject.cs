using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerSO", menuName = "Scriptable Objects/PlayerSO")]
public class PlayerScriptableObject : ScriptableObject
{
    public float localSpeed;
    public float localDefense;
    public float localRangeDamage;
    public float localMeleeDamage;
    public float localShotSpeed;
    public float localMagicDamage;
}
