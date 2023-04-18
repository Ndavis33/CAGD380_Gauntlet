using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //private GameObject _warrior, _valkyrie, _wizard, _elf;
    public EnemyScriptableObject enemySO;
    protected GameObject closestTarget;
    protected Vector3 targetPos;
    protected bool attackingPlayer;
    protected float speed;
    protected int damage;
    protected List<TestMovement> _targets = new List<TestMovement>();

    protected virtual void Init()
    {
        speed = 3f;
        damage = 25;
    }

    private void Start()
    {
        Init();

        foreach (TestMovement target in GameObject.FindObjectsOfType<TestMovement>())
        {
            _targets.Add(target);
            Debug.Log("found target: " + target.name);
        }
    }

    protected virtual void FixedUpdate()
    {
        float minDistanceFromTarget = 420.69f;
        foreach (TestMovement target in _targets)
        {
            if (Vector3.Distance(this.transform.position, target.transform.position) < minDistanceFromTarget)
            {
                if (target.gameObject.activeInHierarchy)
                {
                    minDistanceFromTarget = Vector3.Distance(this.transform.position, target.transform.position);
                    closestTarget = target.gameObject;
                }
            }               
        }

        Debug.Log("Closest Target: " + closestTarget.name);
        targetPos = closestTarget.transform.position;

        if (enemySO.isCoward)
        {
            if (Vector3.Distance(this.transform.position, targetPos) > enemySO.maxAttackRange)
            {
                this.transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime);
            }
            else if (Vector3.Distance(this.transform.position, targetPos) < enemySO.minAttackRange)
            {
                //RunAway();
                Debug.Log("Running");
            }
            else
            {
                if (!attackingPlayer)
                {
                    attackingPlayer = true;
                    //LobObject();
                    Debug.Log("Lobbing");
                }
            }
        }
        else
            this.transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime);   

            
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            attackingPlayer = true;
            StartCoroutine(MeleePlayer(collision.collider.gameObject));
         
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            attackingPlayer = false;
        }
    }

    protected virtual IEnumerator MeleePlayer(GameObject player)
    {
        //example player stats for testing
        damage = 25;
        float playerHP = 100;
        float tempSpeed;
        if (attackingPlayer)
        { 
            while(playerHP > 0)
            {
                Debug.Log("Attacking player");
                playerHP -= damage;

                if(playerHP <= 0)
                {
                    player.SetActive(false);
                    Debug.Log("Target eliminated");
                    break;
                }
                tempSpeed = speed;
                speed = 0;
                yield return new WaitForSeconds(1);
                speed = tempSpeed;

                if (!attackingPlayer)
                    break;

            }
            
        }
        
    }
}
