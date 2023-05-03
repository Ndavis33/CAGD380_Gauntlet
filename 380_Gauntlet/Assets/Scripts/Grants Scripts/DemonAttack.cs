using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonAttack : LobAttack
{
    protected override void Awake()
    {
        _positionOffset = Vector3.forward;
        itemToThrow = "Fireball";
    }
}
