using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Projectile
{
    protected override void Awake()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
        this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        verticalForce = Vector3.zero;
    }
}
