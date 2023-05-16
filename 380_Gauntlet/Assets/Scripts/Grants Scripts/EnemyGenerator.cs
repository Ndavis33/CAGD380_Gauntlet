using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGenerator : MonoBehaviour
{
    private List<EnemyGenerator> _generators = new List<EnemyGenerator>();
    public EnemyScriptableObject enemySO;

    private Vector3 _spawnPos;
    private Vector3 _spawnOffset = new Vector3(0, 0.625f);
    private Vector3 _enemyScale = new Vector3(0.5f, 0.5f, 0.5f);

    [SerializeField]
    private float _spawnRate = 3f;
    //[SerializeField]
    //private int _maxSpawns;
    // its too late for object pooling
    private bool _spawnStarted = false;
    private int _numSpawns = 0;

    private void Awake()
    {
        this.GetComponent<Renderer>().material.color = enemySO.enemyColor;
        _spawnPos = gameObject.transform.position;
        _spawnPos += _spawnOffset;

    }
    
    public void OnPlayButton()
    {
        foreach (EnemyGenerator generator in GameObject.FindObjectsOfType<EnemyGenerator>())
        {
            _generators.Add(generator);
        }

        foreach (EnemyGenerator generator in _generators)
        {
            generator.Init();
        }
    }
    private void Init()
    {
        //_spawnStarted = true;
        //Debug.Log("Generating...");
        StartCoroutine("GenerateSpawns", _spawnRate);
    }

    /*
     * Used for testing
    public void Start()
    {
        //_spawnStarted = true;
        StartCoroutine("GenerateSpawns", _spawnRate);
    }
    */
    private GameObject BetterSpawnEnemy()
    {
        Debug.Log("Generating: " + enemySO.enemyType.ToString());
        GameObject spawn = ObjectPooler.Instance.GetPooledObject(enemySO.enemyType.ToString());

        if(spawn != null)
        {
            spawn.transform.localScale = _enemyScale;
            spawn.tag = enemySO.tagName;
            spawn.transform.position = _spawnPos;
            spawn.GetComponent<EnemyMovement>().enemySO = enemySO;
            spawn.GetComponent<EnemyMovement>().enabled = true;
            spawn.SetActive(true);
        }
        
        return spawn;
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
            BetterSpawnEnemy();
            //_numSpawns++;
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
