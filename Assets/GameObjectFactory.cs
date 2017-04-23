using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectFactory {

    public GameObject[] RocketPrefabs;

    private int poolSize = 0;
    private List<GameObject> objectPool;
    private List<bool> isObjectInUse;

    private Queue<int> queue = new Queue<int>();

    private static object _lock = new object();

    private string prefix;

    public GameObjectFactory(string prefix)
    {
        this.prefix = prefix;
        objectPool = new List<GameObject>();
        isObjectInUse = new List<bool>();
    }

    public GameObject GetObject_BAK()
    {
        lock (_lock)
        {
            for (int i = 0; i < poolSize; i++)
            {
                if (!isObjectInUse[i])
                {
                    isObjectInUse[i] = true;
                    objectPool[i].SetActive(true);
                    return objectPool[i];
                }
            }

            return null;
        }
    }

    public void DestroyObject_BAK(GameObject obj)
    {
        lock (_lock)
        {
            obj.SetActive(false);

            for (int i = 0; i < poolSize; i++)
            {
                if (objectPool[i].name == obj.name)
                {
                    isObjectInUse[i] = false;
                    return;
                }
            }
        }
    }

    public void Add(GameObject obj)
    {
        lock(_lock)
        {
            obj.name = prefix + "_" + poolSize;

            //isObjectInUse.Add(true);
            objectPool.Add(obj);

            poolSize++;
        }
    }

    public GameObject GetObject()
    {
        lock (_lock)
        {
            if (queue.Count == 0)
            {
                return null;
            }

            return objectPool[queue.Dequeue()];
        }
    }

    public void DestroyObject(GameObject obj)
    {
        lock (_lock)
        {
            var name = obj.name;
            var number = int.Parse(name.Replace(prefix + "_", ""));
            queue.Enqueue(number);
        }
    }

    public int ActiveObjects()
    {
        lock (_lock)
        {
            return poolSize - queue.Count;
        }
    }
}
