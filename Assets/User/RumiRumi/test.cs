using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject tesy;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
            tesy.GetComponent<TileData>()._isRope = true;
        if (Input.GetKeyDown(KeyCode.DownArrow))
            tesy.GetComponent<TileData>()._isRope = false;
    }
}
