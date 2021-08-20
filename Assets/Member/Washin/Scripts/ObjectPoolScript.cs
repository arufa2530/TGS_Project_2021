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

    public Transform bulletPoolTransform;


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
                obj.transform.SetParent(bulletPoolTransform);
                enemyBulletPool.Enqueue(obj);
            }

            bulletDictonary.Add(pool.tag, enemyBulletPool);
        }

        bulletPoolTransform = this.transform;
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation, Transform parentTransfrom)
    {
        if (!bulletDictonary.ContainsKey(tag))
        {
            Debug.LogError(tag + "Does not exist as a key for this dictonary");
            return null;
        }

        //GameObject objectToSpawn = bulletDictonary[tag].Dequeue();

        bool isActive = true;
        GameObject objectToSpawn = null;
        while (isActive)
        {
            objectToSpawn = bulletDictonary[tag].Dequeue();
            bulletDictonary[tag].Enqueue(objectToSpawn);
            if (!objectToSpawn.activeInHierarchy) isActive = false;
        }

        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.transform.SetParent(parentTransfrom);
        //bulletDictonary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }

    public void ReturnToPool(string tag, GameObject objectToReturn)
    {
        if (!bulletDictonary.ContainsKey(tag))
        {
            Debug.LogError(tag + "Does not exist as a key for this dictonary");
            return;
        }
        objectToReturn.SetActive(false);
        objectToReturn.GetComponent<PoolBulletScriptTest>().ResetValues();
        objectToReturn.GetComponent<DestroyBulletScript>().ResetValues();
        bulletDictonary[tag].Enqueue(objectToReturn);
        return;
    }

    public Transform GetbulletPoolTransForm()
    {
        return bulletPoolTransform;
    }
}
