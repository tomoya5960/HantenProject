using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            this.transform.position += new Vector3(0, 130, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            this.transform.position += new Vector3(0, -130, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.transform.position += new Vector3(-130, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            this.transform.position += new Vector3(130, 0, 0);
        }
    }
}
