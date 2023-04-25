using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem
{
    public GameObject objectToPool;
    public int amountToPool;
    public bool shouldExpand = true;
}

public class ObjectPooler : MonoBehaviour
{
    private static ObjectPooler _instance;

    public static ObjectPooler Instance
    {
        get { return _instance; }
    }

    public List<GameObject> pooledObjects;
    public List<ObjectPoolItem> itemsToPool;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        pooledObjects = new List<GameObject>();
        foreach (ObjectPoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }

        }

    }

    public GameObject GetPooledObject(string tag)
    {
        //use a for loop to iterate through the list of pooled objects
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            //check to see if the item in our list is currently active or not (this is how we'll know if were using it or not)
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)
            {
                //that means we want to return the first non active GameObject
                return pooledObjects[i];
            }
        }

        foreach (ObjectPoolItem item in itemsToPool)
        {
            if (item.objectToPool.tag == tag)
            {
                if (item.shouldExpand)
                {
                    GameObject obj = (GameObject)Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }

            }
        }
        //we don't have one so if should expand is true, make a new one and return that

        return null;
    }

    //for routines using this method in a loop
    public GameObject GetPooledObject(string tag, int amount)
    {
        if(amount > pooledObjects.Count)
        {
            Debug.Log("Too many pooled objects to get");
            return null;
        }

        //use a for loop to iterate through the list of pooled objects
        for (int i = 0; i < amount; i++)
        {
            //check to see if the item in our list is currently active or not (this is how we'll know if were using it or not)
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)
            {
                //that means we want to return the first non active GameObject
                return pooledObjects[i];
            }
        }

        foreach (ObjectPoolItem item in itemsToPool)
        {
            if (item.objectToPool.tag == tag)
            {
                if (item.shouldExpand)
                {
                    GameObject obj = (GameObject)Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }

            }
        }
        //we don't have one so if should expand is true, make a new one and return that

        return null;
    }
}

