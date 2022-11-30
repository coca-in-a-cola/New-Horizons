using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    protected int poolSize = 10;

    public Transform spawnedObjectsParent;

    public bool alwaysDestroy = false;

    private void Awake()
    {
        
    }

    public void Initialize(int poolSize)
    {
        this.poolSize = poolSize;
    }

    public GameObject CreateObject(GameObject objectToPool, Queue<GameObject> objectPool)
    {

        CreateObjectParentIfNeeded(objectToPool);

        GameObject spawnedObject = null;


        if (objectPool.Count < poolSize)
        {
            spawnedObject = Instantiate(objectToPool, transform.position, Quaternion.identity);
            spawnedObject.name = transform.root.name + "_" + objectToPool.name + "_" + objectPool.Count;
            spawnedObject.transform.SetParent(spawnedObjectsParent);
        }
        else
        {
            spawnedObject = objectPool.Dequeue();
            spawnedObject.transform.position = transform.position;
            spawnedObject.transform.rotation = Quaternion.identity;
            spawnedObject.SetActive(true);
        }

        objectPool.Enqueue(spawnedObject);
        return spawnedObject;
    }

    private void CreateObjectParentIfNeeded(GameObject objectToPool)
    {
        if (spawnedObjectsParent == null)
        {
            string name = "ObjectPool_" + objectToPool.name;
            var parentObject = GameObject.Find(name);
            if (parentObject != null)
                spawnedObjectsParent = parentObject.transform;
            else
            {
                spawnedObjectsParent = new GameObject(name).transform;
            }

        }
    }
}