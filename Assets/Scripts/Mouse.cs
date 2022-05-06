using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField]
    private Transform _imageTransform = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var wh = Input.GetAxis("Mouse ScrollWheel") * 1100;
        _imageTransform.localPosition += new Vector3(0, wh, 0);
    }
}
