using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodCellScript : MonoBehaviour
{
    float rotateSpeed = 100.0f;
    float speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime, Space.Self);
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
