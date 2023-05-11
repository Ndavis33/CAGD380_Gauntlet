using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGenerator : MonoBehaviour
{
    public EnemyScriptableObject enemySO;

    private Vector3 _spawnPos;
    private Vector3 _spawnOffset = new Vector3(0, 0.625f);
    private Vector3 _enemyScale = new Vector3(0.5f, 0.5f, 0.5f);

    [SerializeField]
    private float _spawnRate = 3f;

    private void Awake()
    {
        this.GetComponent<Renderer>().material.color = enemySO.enemyColor;
        _spawnPos = gameObject.transform.position;
        _spawnPos += _spawnOffset;

    }

    public void OnPlayButton()
    {
        StartCoroutine("SpawnEnemy");
    }

    private GameObject SpawnEnemy()
    {
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        obj.transform.localScale = _enemyScale;
        obj.tag = enemySO.tagName;
        obj.transform.position = _spawnPos;
        obj.AddComponent<NavMeshAgent>();
        obj.AddComponent<EnemyMovement>();
        obj.GetComponent<EnemyMovement>().enemySO = enemySO;
        obj.GetComponent<EnemyMovement>().enabled = true;
        return obj;
    }

    private IEnumerator GenerateSpawns(float spawnRate)
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
