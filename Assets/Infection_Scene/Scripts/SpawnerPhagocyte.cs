using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerPhagocyte : MonoBehaviour
{
    [SerializeField]
    GameObject phagocytePrefab;
    [SerializeField]
    List<GameObject> spawners = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "Antiviral")
            InvokeRepeating("InstantiatePhagocyte", 1.0f, Random.Range(2.0f, 4.0f));
        else
            InvokeRepeating("InstantiatePhagocyte", 1.0f,1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject SelectRandomSpawner()
    {
        int index = Random.Range(0, spawners.Count);
        return spawners[index];
    }

    void InstantiatePhagocyte()
    {
        GameObject spawner = SelectRandomSpawner();
        GameObject temp = Instantiate(phagocytePrefab) as GameObject;
        temp.transform.position = spawner.transform.position;
    }
}
