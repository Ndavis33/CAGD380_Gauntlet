using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Inventory", menuName = "Scriptable Objects/InventorySO")]
public class PlayerInventorySO : ScriptableObject
{
    public int numPotions;
    public int numGold;
    public int numFood;
    public int itemValue;
}
