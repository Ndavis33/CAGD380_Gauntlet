using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public EnemyMovement enemy;

    private Rigidbody _rigidbody;

    private Vector3 _startPos, _endPos;
    private Vector3 _targetDirection;
    private Vector3 _jumpForce;
    private Vector3 verticalForce = new Vector3(0, 9);
    //private Vector3 _positionOffset = new Vector3(1.05f, 0.5f);

    private float _speed = .8f;
    private float _timeStart;
    private float _distTraveled;

    private bool _projecting;

    private void Awake()
    {
        //enemy = gameObject.GetComponentInParent<EnemyMovement>();

        _rigidbody = this.GetComponent<Rigidbody>();
        
        

    }


    private void OnEnable()
    {

        //_startPos = _enemy.transform.position;
        //_startPos += _positionOffset;

        //this.transform.position = _startPos;

        //_timeStart = Time.time;

        _targetDirection = enemy.targetPos - this.transform.position;
        _jumpForce = (_targetDirection + verticalForce) * _speed;

        if (enemy == null)
            Debug.Log("enemy null");

        //Debug.Log("direction:  " + _targetDirection);
        //Debug.Log("Shooting toward " + enemy.targetPos + "from: " + this.transform.position + "at a speed of: " + _speed);

        _rigidbody.AddForce(_jumpForce, ForceMode.VelocityChange);
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
        this.gameObject.SetActive(false);
        this.transform.position = _startPos;
        _rigidbody.velocity = Vector3.zero;
        //_enemy.attackingPlayer = false;        
    }
}
