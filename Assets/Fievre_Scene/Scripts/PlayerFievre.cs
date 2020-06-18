using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerFievre : PlayerClass
{
    Vector2 direction;
    Rigidbody2D rb;
    float speed = 10.0f;
    [SerializeField]
    TextMeshProUGUI collectedCytokineText;
    public int collectedCytokines;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(direction, rb, speed);
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            collectedCytokines++;
            collectedCytokineText.text = collectedCytokines.ToString();
        }
    }
}
