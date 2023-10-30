using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int initialSize;
    }

    public List<Pool> pools;

    public Dictionary<string, Queue<GameObject>> m_poolDictionary;

    private void Start()
    {
        m_poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectpool = new Queue<GameObject>();

            for (int i = 0; i < pool.initialSize; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectpool.Enqueue(obj);
            }

          //  m_poolDictionary.Add(pool.tag,objectpool);
        }

        m_poolDictionary = new Dictionary<string, Queue<GameObject>>();
    }

    public GameObject returnObject(string tag, Vector3 position, Quaternion rotation)
    {
        if (!m_poolDictionary.ContainsKey(tag))
        {
            Debug.Log("it's broken");
            return null;
        
        }
        GameObject SpawningObj = m_poolDictionary[tag].Dequeue();
        SpawningObj.SetActive(true);
        SpawningObj.transform.SetPositionAndRotation(position, rotation);

        m_poolDictionary[tag].Enqueue(SpawningObj);


        return SpawningObj;
    }
}
