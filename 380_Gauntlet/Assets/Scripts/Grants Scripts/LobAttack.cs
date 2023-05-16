using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobAttack : MonoBehaviour, IAttackBehavior
{
    public GameObject attackTarget;

    protected string itemToThrow;

    protected Vector3 _positionOffset;
    private Vector3 _projectileStartPos;

    [SerializeField]
    private float _attackRate = 3f;

    protected virtual void Awake()
    {
        _positionOffset = new Vector3(-1.05f, 0.5f);
        itemToThrow = "Lobber Projectile";
    }
  
    public void Attack(EnemyMovement attacker, PlayerMovement target)
    {
        attackTarget = target.gameObject;
        Debug.Log("attacker: " + attacker.name);
        StartCoroutine(Shoot(attacker));
        //throw new System.NotImplementedException();
    }

    private IEnumerator Shoot(EnemyMovement attacker)
    {

        GameObject projectile = ObjectPooler.Instance.GetPooledObject(itemToThrow);
        Debug.Log("Throwing: " + itemToThrow);
        
        if (projectile != null && attacker.attackingPlayer)
        {
            _projectileStartPos = attacker.transform.position;
            _projectileStartPos += _positionOffset;
            projectile.transform.position = _projectileStartPos;
            projectile.transform.localRotation = attacker.transform.rotation;
            if(itemToThrow == "Lobber Projectile")
            {
                Debug.Log("Getting projectile");
                projectile.GetComponent<Projectile>().enabled = true;
                projectile.GetComponent<Projectile>().enemy = this.gameObject.GetComponent<EnemyMovement>();
            }
            else if(itemToThrow == "Fireball")
            {
                Debug.Log("Getting fireball");
                projectile.GetComponent<FireBall>().enabled = true;
                projectile.GetComponent<FireBall>().enemy = this.gameObject.GetComponent<EnemyMovement>();
            }
            
            projectile.SetActive(true);
            
            Debug.Log("throwing item");

        }

        yield return new WaitForSeconds(attacker.enemySO.attackRate);
        attacker.attackingPlayer = false;
    }
}
