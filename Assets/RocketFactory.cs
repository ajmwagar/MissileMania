using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum RocketType
{
    Simple = 0,
    Guided = 1
}

public class RocketFactory : MonoBehaviour {

    private static RocketFactory _instance;
    private static RocketFactory Instance { get { return _instance; } }
    private Dictionary<RocketType, GameObjectFactory> factory;

    public Vector3 graveyardPosition;
    public GameObject[] RocketPrefabs;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;

            factory = new Dictionary<RocketType, GameObjectFactory>();

            factory.Add(RocketType.Simple, new GameObjectFactory("simple"));
            factory.Add(RocketType.Guided, new GameObjectFactory("guided"));

            graveyardPosition = new Vector3(0, -2000, 0);
        }
    }

    public static GameObject CreateRocket(RocketType type)
    {
        var rocket = Instance.factory[type].GetObject();

        if(rocket == null)
        {
            rocket = Instantiate(Instance.RocketPrefabs[0], Vector3.zero, Quaternion.identity);
            Instance.factory[type].Add(rocket);
        }

        return rocket;
    }

    public static void DestroyRocket(GameObject rocket, RocketType type)
    {
        rocket.SetActive(false);
        rocket.transform.position = Instance.graveyardPosition;
        Instance.factory[type].DestroyObject(rocket);
    }
}
