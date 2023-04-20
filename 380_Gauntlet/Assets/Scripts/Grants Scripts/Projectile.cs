using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private EnemyMovement _enemy;
    private LobAttack _thrower;

    private Rigidbody _rigidbody;

    private Vector3 _startPos, _endPos;
    private Vector3 targetPos;
    private Vector3 _jumpForce;

    private float _positionOffset = 1f;
    private float _speed = 9;
    private float _timeStart;
    private float _distTraveled;

    private bool _projecting;

    private void Awake()
    {
        _enemy = gameObject.GetComponentInParent<EnemyMovement>();
        _thrower = gameObject.GetComponentInParent<LobAttack>();

        _rigidbody = this.GetComponent<Rigidbody>();
        _jumpForce = new Vector3(0, 1, -1) * _speed;

    }

    private void OnEnable()
    {
        _startPos = this.transform.position;

        _timeStart = Time.time;

        //_projecting = true;

        _rigidbody.AddForce(_jumpForce, ForceMode.Impulse);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            //damage player
            ResetPosition();
           
        }

        if (collision.collider.gameObject.CompareTag("Boundary"))
        {
            _endPos = this.transform.position;
            _distTraveled = Vector3.Distance(_startPos, _endPos);
            Debug.Log("Distance traveled: " + _distTraveled);
            ResetPosition();


        }
    }

    private void ResetPosition()
    {   
        this.transform.position = _startPos;
        this.gameObject.SetActive(false);
        _enemy.attackingPlayer = false;
        
    }
}
