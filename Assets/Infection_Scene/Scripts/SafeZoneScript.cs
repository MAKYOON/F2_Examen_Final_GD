using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneScript : MonoBehaviour
{
    float randomX;
    float randomY;
    float orthographicSize;
    float screenRatio;
    [SerializeField]
    GameObject virus;
    // Start is called before the first frame update
    void Start()
    {
        orthographicSize = Camera.main.orthographicSize;
        screenRatio = (float)Screen.width / Screen.height;
        SetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector2 GetRandomPosition()
    {  
        randomX = Random.Range(-(orthographicSize * screenRatio) + 1, orthographicSize * screenRatio - 1); 
        randomY = Random.Range(-orthographicSize + 1, orthographicSize - 1);
        return new Vector2(randomX, randomY);
    }

    void SetPosition()
    {
        Vector2 newPosition = GetRandomPosition();
        transform.position = newPosition;
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.name == "PlayerInfection")
        {
            GameObject temp = Instantiate(virus) as GameObject;
            temp.transform.position = this.transform.position;
            SetPosition();
        }
    }
}
