using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour
{
    Rigidbody2D rb2d;
    float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        rb2d.AddForce(Vector2.right * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "Border")
        {
            gameObject.SetActive(false);
        }
    }
}
