using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactor : MonoBehaviour
{
    public float speed = 1.0f;
    public float speedwheel = 15f;

    void Update()
    {
        if (Input.mouseScrollDelta.y>0 )
        {
            transform.position += transform.up * speedwheel * Time.deltaTime;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            transform.position -= transform.up * speedwheel * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) || (Input.GetKey(KeyCode.D)))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.A)))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }

    }

}