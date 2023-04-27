using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //private GameObject _warrior, _valkyrie, _wizard, _elf;
    public EnemyScriptableObject enemySO;
    public GameObject closestTarget;
    private PlayerMovement _player;
    public Vector3 targetPos;
    public float startHealth;
    public bool attackingPlayer = false;
    private bool _still;
    protected List<PlayerMovement> _targets = new List<PlayerMovement>();

    private void Awake()
    {
        startHealth = enemySO.health;
    }

    private void Start()
    {
        foreach (PlayerMovement target in GameObject.FindObjectsOfType<PlayerMovement>())
        {
            _targets.Add(target);
            Debug.Log("found target: " + target.name);
        }
    }

    public void ApplyStrategy(IAttackBehavior strategy, GameObject target)
    {
        strategy.Attack(this, target);
    }

    protected virtual void FixedUpdate()
    {
        if(_targets.Count == 0)
        {
            Debug.Log("Still looking for targets");
            Start();
        }
        else
        {
            float minDistanceFromTarget = 420.69f;
            foreach (PlayerMovement target in _targets)
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

            /*
            Vector3 targetDirection = targetPos - this.transform.position;
            Vector3 newDirection = Vector3.RotateTowards(this.transform.forward, targetDirection, enemySO.speed * Time.deltaTime, 0.0f);
            this.transform.rotation = Quaternion.LookRotation(newDirection);
            */


            if (enemySO.isCoward)
            {
                if (Vector3.Distance(this.transform.position, targetPos) > enemySO.maxAttackRange)
                {
                    _still = false;
                    Debug.Log("Following");
                    this.transform.position = Vector3.MoveTowards(transform.position, targetPos, enemySO.speed * Time.fixedDeltaTime);
                }
                else if (Vector3.Distance(this.transform.position, targetPos) < enemySO.minAttackRange)
                {
                    _still = false;
                    this.transform.position = Vector3.MoveTowards(transform.position, targetPos, -enemySO.speed * Time.fixedDeltaTime);
                    Debug.Log("Running");
                }
                else if (Vector3.Distance(this.transform.position, targetPos) > enemySO.minAttackRange && Vector3.Distance(this.transform.position, targetPos) < enemySO.maxAttackRange)
                {
                    if (!attackingPlayer)
                    {
                        attackingPlayer = true;

                        if (!this.GetComponent<LobAttack>())
                            this.gameObject.AddComponent<LobAttack>();

                        ApplyStrategy(this.GetComponent<LobAttack>(), closestTarget);



                        Debug.Log("Lobbing");
                    }
                }
                else
                    Debug.Log("bruh");
            }
            else
                this.transform.position = Vector3.MoveTowards(transform.position, targetPos, enemySO.speed * Time.fixedDeltaTime);
        }

                       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {

            if (enemySO.isSuicidal)
            {
                //get player's health and decrease it by enemySO.damage
                this.gameObject.SetActive(false);
            }
            else
            {
                attackingPlayer = true;

                if (!this.GetComponent<BasicMeleeAttack>())
                    this.gameObject.AddComponent<BasicMeleeAttack>();

                ApplyStrategy(this.GetComponent<BasicMeleeAttack>(), collision.collider.gameObject);

            }                     
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            attackingPlayer = false;
        }

    }

    private void TakeDamage(int damage)
    {
        enemySO.health -= damage;
        if(enemySO.health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

}
