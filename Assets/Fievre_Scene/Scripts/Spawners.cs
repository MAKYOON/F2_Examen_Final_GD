using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    public int poolCount;
    List<GameObject> objectPool;
    [SerializeField]
    GameObject objectToInstantiate;
    [SerializeField]
    GameObject poolHolder;

    // Start is called before the first frame update
    void Start()
    {
        objectPool = new List<GameObject>();
        CreateObjectPool();
        InvokeRepeating("SpawnCell", Random.Range(0,2f), Random.Range(2f,5f));
    }

    void CreateObjectPool()
    {
        for (int i = 0; i < poolCount; i++)
        {
            GameObject temp = Instantiate(objectToInstantiate) as GameObject;
            objectPool.Add(temp);
            temp.transform.SetParent(poolHolder.transform);
            temp.SetActive(false);
        }
    }

    GameObject GetCellFromPool()
    {
        for (int i = 0; i < objectPool.Count; i++)
        {
            if (!objectPool[i].activeInHierarchy)
            {
                return objectPool[i];
            }
        }
        return null;
    }

    void SpawnCell()
    {
        GameObject cell = GetCellFromPool();
        if (cell != null)
        {
            cell.transform.position = this.transform.position;
            cell.SetActive(true);
        }
    }
}
