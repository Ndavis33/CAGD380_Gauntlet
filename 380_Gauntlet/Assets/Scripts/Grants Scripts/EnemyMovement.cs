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
    public float localSpeed;
    public bool attackingPlayer = false;
    private bool _canBlink = true;
    public bool _escaping = false;
    protected List<PlayerMovement> _targets = new List<PlayerMovement>();
    

    private void Awake()
    {
        //startHealth = enemySO.health;
        //this.GetComponent<Renderer>().material.color = enemySO.enemyColor;
    }

    private void Start()
    {
        localSpeed = enemySO.speed;
        startHealth = enemySO.health;
        this.GetComponent<Renderer>().material.color = enemySO.enemyColor;

        foreach (PlayerMovement target in GameObject.FindObjectsOfType<PlayerMovement>())
        {
            _targets.Add(target);
            Debug.Log("found target: " + target.name);
        }
    }

    public void ApplyStrategy(IAttackBehavior strategy, PlayerMovement target)
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
                        //need to make thief target richest player when points are established
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

            switch (enemySO.enemyType)
            {
                case EnemyType.Demon:

                    if (Vector3.Distance(this.transform.position, targetPos) > enemySO.minAttackRange)
                    {
                        if (!attackingPlayer)
                        {
                            attackingPlayer = true;

                            if (!this.GetComponent<DemonAttack>())
                                this.gameObject.AddComponent<DemonAttack>();

                            ApplyStrategy(this.GetComponent<DemonAttack>(), closestTarget.GetComponent<PlayerMovement>());



                            Debug.Log("Firing ball");
                        }
                    }

                    this.transform.position = Vector3.MoveTowards(transform.position, targetPos, localSpeed * Time.fixedDeltaTime);

                    break;
                case EnemyType.Lobber:

                    if (Vector3.Distance(this.transform.position, targetPos) > enemySO.maxAttackRange)
                    {
                        Debug.Log("Following");
                        this.transform.position = Vector3.MoveTowards(transform.position, targetPos, localSpeed * Time.fixedDeltaTime);
                    }
                    else if (Vector3.Distance(this.transform.position, targetPos) < enemySO.minAttackRange)
                    {
                        this.transform.position = Vector3.MoveTowards(transform.position, targetPos, -localSpeed * Time.fixedDeltaTime);
                        Debug.Log("Running");
                    }
                    else if (Vector3.Distance(this.transform.position, targetPos) > enemySO.minAttackRange && Vector3.Distance(this.transform.position, targetPos) < enemySO.maxAttackRange)
                    {
                        if (!attackingPlayer)
                        {
                            attackingPlayer = true;

                            if (!this.GetComponent<LobAttack>())
                                this.gameObject.AddComponent<LobAttack>();

                            ApplyStrategy(this.GetComponent<LobAttack>(), closestTarget.GetComponent<PlayerMovement>());



                            Debug.Log("Lobbing");
                        }
                    }
                    else
                        Debug.Log("Vector3.Distance calculation error");

                    break;
                case EnemyType.Sorcerer:

                    if (Vector3.Distance(this.transform.position, targetPos) > enemySO.maxAttackRange && _canBlink)
                    {

                        _canBlink = false;
                        Debug.Log("Blinking");
                        //_blinking = true;
                        StartCoroutine(Blink());
                    }

                    this.transform.position = Vector3.MoveTowards(transform.position, targetPos, localSpeed * Time.fixedDeltaTime);
                    break;

                case EnemyType.Thief:
                    if(!_escaping)
                        this.transform.position = Vector3.MoveTowards(transform.position, targetPos, localSpeed * Time.fixedDeltaTime);
                    else
                    {
                        this.transform.position = Vector3.MoveTowards(transform.position, targetPos, -localSpeed * Time.fixedDeltaTime);
                        if (!IsObjectVisible(this.gameObject, closestTarget.GetComponentInChildren<Camera>()))
                            gameObject.SetActive(false);
                    }
                        

                    break;

                default:
                    this.transform.position = Vector3.MoveTowards(transform.position, targetPos, localSpeed * Time.fixedDeltaTime);
                    break;
            }
                
        }

                       
    }

    //Nate needs to add a rigidbody to the player before continuing with Death
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Attacking Player");
            attackingPlayer = true;
            _canBlink = false;

            this.GetComponent<Renderer>().material.color = Color.yellow;

            switch (enemySO.enemyType)
            {
                case EnemyType.Death:
                    if (!this.GetComponent<DeathAttack>())
                        this.gameObject.AddComponent<DeathAttack>();

                    ApplyStrategy(this.GetComponent<DeathAttack>(), collision.collider.gameObject.GetComponent<PlayerMovement>());

                    break;

                case EnemyType.Demon:
                    if (!this.GetComponent<BasicMeleeAttack>())
                        this.gameObject.AddComponent<BasicMeleeAttack>();

                    ApplyStrategy(this.GetComponent<BasicMeleeAttack>(), collision.collider.gameObject.GetComponent<PlayerMovement>());
                    break;

                case EnemyType.Ghost:
                    if (!this.GetComponent<GhostAttack>())
                        this.gameObject.AddComponent<GhostAttack>();

                    ApplyStrategy(this.GetComponent<GhostAttack>(), collision.collider.gameObject.GetComponent<PlayerMovement>());
                    break;

                case EnemyType.Grunt:
                    if (!this.GetComponent<BasicMeleeAttack>())
                        this.gameObject.AddComponent<BasicMeleeAttack>();

                    ApplyStrategy(this.GetComponent<BasicMeleeAttack>(), collision.collider.gameObject.GetComponent<PlayerMovement>());
                    break;

                case EnemyType.Lobber:
                    if (!this.GetComponent<LobAttack>())
                        this.gameObject.AddComponent<LobAttack>();

                    ApplyStrategy(this.GetComponent<LobAttack>(), collision.collider.gameObject.GetComponent<PlayerMovement>());
                    break;

                case EnemyType.Sorcerer:
                    if (!this.GetComponent<BasicMeleeAttack>())
                        this.gameObject.AddComponent<BasicMeleeAttack>();

                    ApplyStrategy(this.GetComponent<BasicMeleeAttack>(), collision.collider.gameObject.GetComponent<PlayerMovement>());
                    break;

                case EnemyType.Thief:

                    if (!this.GetComponent<ThiefAttack>())
                        this.gameObject.AddComponent<ThiefAttack>();

                    ApplyStrategy(this.GetComponent<ThiefAttack>(), collision.collider.gameObject.GetComponent<PlayerMovement>());
                    break;

                default:
                    break;
            }

            this.GetComponent<Renderer>().material.color = enemySO.enemyColor;

        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            attackingPlayer = false;
            _canBlink = true;
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

    private IEnumerator Blink()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(1f);
        this.gameObject.GetComponent<Renderer>().enabled = true;
        //yield return new WaitForSeconds(1f);
        _canBlink = true;
     
    }

    private bool IsObjectVisible(GameObject _object, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        if (GeometryUtility.TestPlanesAABB(planes, _object.GetComponent<Collider>().bounds))
            return true;
        else
            return false;
    }

}
