using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFactory : MonoBehaviour {

    private static RocketFactory _instance;

    public static RocketFactory Instance { get { return _instance; } }

    private static object _lock = new object();
    public int poolSize = 0;

    public GameObject[] Prefabs;

    private List<GameObject> objectPool;
    private List<bool> isObjectInUse;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            objectPool = new List<GameObject>();
            isObjectInUse = new List<bool>();
        }
    }

    public GameObject GetRocket()
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

            var rocket = Instantiate(Prefabs[0], Vector3.zero, Quaternion.identity);
            rocket.name = "rocket_" + poolSize;

            isObjectInUse.Add(true);
            objectPool.Add(rocket);

            poolSize++;

            return rocket;
        }
    }

    public void DestroyRocket(GameObject obj)
    {
        lock(_lock)
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
}
