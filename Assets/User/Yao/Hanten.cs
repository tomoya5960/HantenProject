using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hanten : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    Quaternion angle = Quaternion.identity;

    void Update()
    {
        // �}�E�X�̍��{�^���h���b�O���ė������甽�]
        if (Input.GetMouseButtonDown(0))
        {
            angle.eulerAngles = new Vector3(0, 180f, 0);
            transform.rotation = angle;
        }
       
    }
}
