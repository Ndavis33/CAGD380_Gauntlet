using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private EnemyMovement _enemy;

    private Vector3 startPos;

    private float _positionOffset = 5.0f;
    private float _speed = 5;
    private float _timeStart;

    private bool _projecting;

    private void Awake()
    {
        _enemy = gameObject.GetComponentInParent<EnemyMovement>();
    }

    private void OnEnable()
    {
        startPos = _enemy.gameObject.transform.position;
        startPos.y += _positionOffset;
        this.transform.position = startPos;

        _timeStart = Time.time;

        _projecting = true;
    }

    private void Update()
    {
        if (_projecting)
        {
            Debug.Log("Projecting");
            //I am 95% sure I didn't use this method right
            float u = (Time.time - _timeStart) / _speed;
            Vector3.Lerp(this.transform.position, _enemy.targetPos, u);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
