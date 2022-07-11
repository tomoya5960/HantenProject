using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landscape : MonoBehaviour
{
    [SerializeField]
    GameObject fire;
    public int a = 130;
    Vector3 Firepos;
    [SerializeField]
    private int firenum = 0;
    [SerializeField]
    List<GameObject> LandscapeFires = new List<GameObject>();

    private void Awake()
    {
        fire = (GameObject)Resources.Load("Side Fire");

    }
    void Start()
    {
     //   if (GetComponent<TileData>().imageID != (int)MapType.ImageIdType.statue_01)
      //  {
     //       this.gameObject.GetComponent<Landscape>().enabled = false;
    //    }
        Firenums();
    }

    // Update is called once per frame
    void Firenums()
    {
        for (int num = 0; num < firenum; num++)
        {
            Firepos = new Vector3(130 + a * num, 0.0f, 0.0f);
            var LandscapeImage = Instantiate(fire, Vector3.zero, Quaternion.identity, GameObject.Find("Canvas").transform);
            LandscapeImage.GetComponent<RectTransform>().anchoredPosition = Firepos;
            LandscapeFires.Add(LandscapeImage);
        }
    }
}
