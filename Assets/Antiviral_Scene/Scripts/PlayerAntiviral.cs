using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAntiviral : MonoBehaviour
{
    float speed = 9.0f;
    Rigidbody2D rb;
    public int poolCount;
    List<GameObject> objectPool = new List<GameObject>();
    [SerializeField]
    GameObject objectToInstantiate;
    [SerializeField]
    GameObject poolHolder;
    public int virusPassed;
    public GameObject lose;

    private bool coroutineStarted;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CreateObjectPool();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }

        if (lose.activeInHierarchy && !coroutineStarted)
        {
            coroutineStarted = true;
            StartCoroutine(EndLevel());
        }

    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Move(new Vector2(horizontal, vertical));
    }

    void Fire()
    {
        SpawnAmmo();
    }

    void Move(Vector2 move)
    {
        rb.MovePosition(transform.position + (Vector3)move * Time.deltaTime * speed);
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

    GameObject GetAmmoFromPool()
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

    void SpawnAmmo()
    {
        GameObject ammo = GetAmmoFromPool();
        if (ammo != null)
        {
            ammo.transform.position = this.transform.position + new Vector3 (1,0,0);
            ammo.SetActive(true);
        }
    }
    
    IEnumerator EndLevel()
    {
        Debug.Log("coroutine started");
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(2.0f);
        SceneManager.LoadScene("MainMenu");
    }
}
