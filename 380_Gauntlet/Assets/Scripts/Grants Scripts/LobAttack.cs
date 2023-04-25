using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobAttack : MonoBehaviour, IAttackBehavior
{
    public GameObject attackTarget;

    private Vector3 _positionOffset = new Vector3(-1.05f, 0.5f);
    private Vector3 _projectileStartPos;

    [SerializeField]
    private float _attackRate = 3f;
  
    public void Attack(EnemyMovement attacker, GameObject target)
    {
        attackTarget = target;
        Debug.Log("lobbing player");
        StartCoroutine(Lob(attacker));
        //throw new System.NotImplementedException();
    }

    private IEnumerator Lob(EnemyMovement attacker)
    {
        //yield return new WaitForSeconds(1);

        GameObject projectile = ObjectPooler.Instance.GetPooledObject("Lobber Projectile");
        //Debug.Log(projectile.name);
        //yield return new WaitForSeconds(_attackRate);

        
        if (projectile != null && attacker.attackingPlayer)
        {
            _projectileStartPos = attacker.transform.position;
            _projectileStartPos += _positionOffset;
            projectile.transform.position = _projectileStartPos;
            projectile.transform.localRotation = attacker.transform.rotation;
            projectile.SetActive(true);
            Debug.Log("attacking player");

        }

        yield return new WaitForSeconds(_attackRate);
        attacker.attackingPlayer = false;
    }
}
