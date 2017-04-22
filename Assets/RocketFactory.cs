using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFactory : MonoBehaviour {

    private static RocketFactory _instance;

    public static RocketFactory Instance { get { return _instance; } }

    public bool debug;
    private static object _lock = new object();

    public Vector3 graveyardPosition;
    public GameObject[] RocketPrefabs;

    private int poolSize = 0;
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
            graveyardPosition = new Vector3(0, -2000, 0);
            _instance = this;
            objectPool = new List<GameObject>();
            isObjectInUse = new List<bool>();
        }
    }

    public GameObject CreateRocket()
    {
        lock (_lock)
        {
            for (int i = 0; i < poolSize; i++)
            {
                if (!isObjectInUse[i])
                {
                    LogMsg("Rocket reused: " + objectPool[i].name);
                    isObjectInUse[i] = true;
                    objectPool[i].SetActive(true);
                    return objectPool[i];
                }
            }

            var rocket = Instantiate(RocketPrefabs[0], Vector3.zero, Quaternion.identity);
            rocket.name = "rocket_" + poolSize;

            isObjectInUse.Add(true);
            objectPool.Add(rocket);

            poolSize++;

            LogMsg("Rocket created: " + rocket.name);

            return rocket;
        }
    }

    public void DestroyRocket(GameObject rocket)
    {
        lock(_lock)
        {
            LogMsg("Rocket destroyed: " + rocket.name);
            rocket.SetActive(false);
            rocket.transform.position = graveyardPosition;

            for (int i = 0; i < poolSize; i++)
            {
                if (objectPool[i].name == rocket.name)
                {
                    isObjectInUse[i] = false;
                    return;
                }
            }
        }
    }

    private void LogMsg(string msg)
    {
        if(!debug)
        {
            return;
        }

        Debug.Log(msg);
    }
}
