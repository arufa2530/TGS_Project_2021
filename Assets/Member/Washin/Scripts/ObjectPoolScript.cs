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

    //タグを使ってそれぞれのゲームオブジェクトをゲットする
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation, Transform parentTransfrom)
    {
        //タグが存在しているかどうかチェックする
        if (!bulletDictonary.ContainsKey(tag))
        {
            //存在していない場合リターンする
            Debug.LogError(tag + "Does not exist as a key for this dictonary");
            return null;
        }

        bool isActive = true;
        GameObject objectToSpawn = null;

        //使ってないゲームオブジェクトを探す
        //ロケット鉛筆考えると想像できる
        while (isActive)
        {
            //一番最初のオブジェクト最後になる
            //そのオブジェクトを使っているなら
            //もう一回リロードする
            objectToSpawn = bulletDictonary[tag].Dequeue();
            bulletDictonary[tag].Enqueue(objectToSpawn);

            //そのオブジェクト使ってない場合、Whileループから出る
            if (!objectToSpawn.activeInHierarchy) isActive = false;
        }

        //オブジェクト設定する
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.transform.SetParent(parentTransfrom);

        //オブジェクトを出す
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
