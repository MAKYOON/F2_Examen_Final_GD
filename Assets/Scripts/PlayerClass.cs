using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour
{ 
    public void Move(Vector2 direction, Rigidbody2D rb, float speed)
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.MovePosition((Vector2)transform.position + direction * speed * Time.fixedDeltaTime);
    }


}
