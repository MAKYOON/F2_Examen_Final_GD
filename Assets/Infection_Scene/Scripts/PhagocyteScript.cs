using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhagocyteScript : MonoBehaviour
{
    static GameObject target;

    float speed = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
            target = GameObject.Find("PlayerInfection");
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Atan2(target.transform.position.y, target.transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
        transform.position = Vector2.MoveTowards((Vector2)transform.position, (Vector2)target.transform.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.name == "PlayerInfection")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
