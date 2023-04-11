using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerSO", menuName = "PlayerSO")]
public class PlayerScriptableObject : ScriptableObject
{
    public float localSpeed;
    public float localDefense;
    public float localPhysicalDamage;
    public float localMagicDamage;
}
