using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolScript : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject bulletPrefab;
        public int sizeOfPool;
    }

    public static ObjectPoolScript Instance;
    private void Awake()
    {
        Instance = this;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> bulletDictonary;


    void Start()
    {
        bulletDictonary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> enemyBulletPool = new Queue<GameObject>();

            for (int i = 0; i < pool.sizeOfPool; i++)
            {
                GameObject obj = Instantiate(pool.bulletPrefab);
                obj.SetActive(false);
                enemyBulletPool.Enqueue(obj);
            }

            bulletDictonary.Add(pool.tag, enemyBulletPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!bulletDictonary.ContainsKey(tag))
        {
            Debug.LogError(tag + "Does not exist as a key for this dictonary");
            return null;
        }

        GameObject objectToSpawn = bulletDictonary[tag].Dequeue();

        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        bulletDictonary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }


}
