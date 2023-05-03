using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefAttack : MonoBehaviour, IAttackBehavior
{
    private int _timesHitWall = 0;

    private float _startSpeed;

    private Vector3 _rightTurn = new Vector3(0, 90f, 0);

    public void Attack(EnemyMovement attacker, PlayerMovement target)
    {
        _startSpeed = attacker.enemySO.speed;
        StartCoroutine(RobPlayer(attacker, target));
        //throw new System.NotImplementedException();
    }

    private IEnumerator RobPlayer(EnemyMovement attacker, PlayerMovement target)
    {
        target.playerHealth -= attacker.enemySO.damage;
        attacker._escaping = true;
        yield return null;
        /*
        while (true)
        {
            this.transform.position += Vector3.back;
            yield return new WaitForSeconds(2);
            if(_timesHitWall >= 2)
            {
                Debug.Log("Cornered; Giving up.");
                break;
            }


        }
        */
    }
    private void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Boundary"))
        {
            this.gameObject.GetComponent<EnemyMovement>().enemySO.speed = 0;
            _timesHitWall++;
            transform.Rotate(_rightTurn);
            this.gameObject.GetComponent<EnemyMovement>().enemySO.speed = _startSpeed;


        }
    }
}
