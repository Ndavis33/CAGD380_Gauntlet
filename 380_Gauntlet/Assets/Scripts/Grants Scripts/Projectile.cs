using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public EnemyMovement enemy;

    protected Rigidbody _rigidbody;

    private Vector3 _startPos, _endPos;
    private Vector3 _targetDirection;
    private Vector3 _shotForce;
    protected Vector3 verticalForce; 
    //private Vector3 _positionOffset = new Vector3(1.05f, 0.5f);

    private float _speed = 0.8f;
    private float _timeStart;
    private float _distTraveled;
    private float _lifetime = 3f;

    private bool _projecting;

    protected virtual void Awake()
    {
        //enemy = gameObject.GetComponentInParent<EnemyMovement>();

        _rigidbody = this.GetComponent<Rigidbody>();
        this.GetComponent<Renderer>().material.color = Color.gray;

        verticalForce = new Vector3(0, 9);



    }

    private void OnEnable()
    {

        //_startPos = _enemy.transform.position;
        //_startPos += _positionOffset;

        //this.transform.position = _startPos;

        //_timeStart = Time.time;
        StartCoroutine(KillTimer());

        _targetDirection = enemy.targetPos - this.transform.position;
        _shotForce = (_targetDirection + verticalForce) * _speed;

        if (enemy == null)
            Debug.Log("enemy null");

        //Debug.Log("direction:  " + _targetDirection);
        //Debug.Log("Shooting toward " + enemy.targetPos + "from: " + this.transform.position + "at a speed of: " + _speed);

        _rigidbody.AddForce(_shotForce, ForceMode.VelocityChange);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            enemy.closestTarget.GetComponent<PlayerMovement>().playerHealth -= enemy.enemySO.damage;
            if (enemy.closestTarget.GetComponent<PlayerMovement>().playerHealth <= 0)
                collision.collider.gameObject.SetActive(false);

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

    private IEnumerator KillTimer()
    {
        yield return new WaitForSeconds(_lifetime);
        this.gameObject.SetActive(false);
    }

    private void ResetPosition()
    {   
        this.gameObject.SetActive(false);
        this.transform.position = _startPos;
        _rigidbody.velocity = Vector3.zero;
        //_enemy.attackingPlayer = false;        
    }
}
