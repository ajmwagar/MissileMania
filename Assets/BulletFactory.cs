using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BulletType
{
    Simple = 0
}

public class BulletFactory : MonoBehaviour
{

    private static BulletFactory _instance;
    private static BulletFactory Instance { get { return _instance; } }
    private Dictionary<BulletType, GameObjectFactory> factory;

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

            factory = new Dictionary<BulletType, GameObjectFactory>();

            factory.Add(BulletType.Simple, new GameObjectFactory("bullet_simple"));

            graveyardPosition = new Vector3(0, -2000, 0);
        }
    }

    public static GameObject CreateBullet(BulletType type)
    {
        var bullet = Instance.factory[type].GetObject();

        if (bullet == null)
        {
            bullet = Instantiate(Instance.RocketPrefabs[0], Instance.graveyardPosition, Quaternion.identity);
            Instance.factory[type].Add(bullet);
        }

        bullet.SetActive(true);
        return bullet;
    }

    public static void DestroyBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bullet.transform.position = Instance.graveyardPosition;
        Instance.factory[BulletType.Simple].DestroyObject(bullet);
    }
}
