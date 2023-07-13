using System.Collections;
using System.Collections.Generic;
using Assets._Main.Scripts.Generic_Pool;
using UnityEngine;

public class GenericPool : MonoBehaviour
{
    public List<PoolObject> poolsList;
    public Dictionary<PoolObject, Queue<GameObject>> poolDictionary;
    public static GenericPool Instance;
    private void Awake()
    {
        Instance = this;   
    }
    private void Start()
    {
        poolDictionary = new Dictionary<PoolObject, Queue<GameObject>>();
        foreach (PoolObject pool in poolsList)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i <pool.PoolSize; i++)
            {
                GameObject obj = Instantiate(pool.ObjectToPool);
                //obj.transform.parent = pool.objectFather.transform;
                    obj.transform.SetParent(transform);
                    obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool, objectPool);
        }
    }
    public GameObject SpawnFromPool(PoolObject poolObject,Vector3 posToSpawn, Quaternion rotation)
    {
        if (poolObject == null)
        {
            print("el objeto que estas intentando spawnear no existe");
            return null;
        }
        if (!poolDictionary.ContainsKey(poolObject)) // Chequeo de si la key existe
        {
            Debug.LogWarning("no existe pool con" + poolObject.name);
            return null;
        }
       
        GameObject objectToSpawn = poolDictionary[poolObject].Dequeue();
        if (!objectToSpawn.activeSelf)
        {
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = posToSpawn;
            objectToSpawn.transform.rotation = rotation;
        }
        else
        {
            var newObject = Instantiate(objectToSpawn.gameObject, objectToSpawn.transform.parent, true);
            poolDictionary[poolObject].Enqueue(objectToSpawn);
            objectToSpawn = newObject;
        }

        
        
        IPooleable pooledObj = objectToSpawn.GetComponent<IPooleable>();
        if(pooledObj != null)
        {
            pooledObj.OnObjectSpawn();
        }
        poolDictionary[poolObject].Enqueue(objectToSpawn);
        return objectToSpawn;
        
    }
}
