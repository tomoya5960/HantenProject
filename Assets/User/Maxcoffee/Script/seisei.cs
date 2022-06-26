
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class seisei : MonoBehaviour
{
    // ƒvƒŒƒnƒuŠi”[—p
    public GameObject CubePrefab;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = new Vector3(0.0f, 130.0f, 0.0f);
        CubePrefab.transform.localScale = new Vector3(1, 1.0f, 1);
        Instantiate(CubePrefab, pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    { 
    }
}