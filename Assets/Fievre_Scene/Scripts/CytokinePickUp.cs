﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CytokinePickUp : MonoBehaviour
{
    float speed = 8.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
