using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upturn : MonoBehaviour
{
    [SerializeField]
    GameObject fire;
    public int a = 130;
    Vector3 Firepos;
    [SerializeField]
    private int firenum = 0;
    [SerializeField]
    List<GameObject> UpFires = new List<GameObject>();

    private void Awake()
    {
        fire = (GameObject)Resources.Load("Up Fire");

    }
    void Start()
    {
        /*if (GetComponent<TileData>().imageID != (int)MapType.ImageIdType.statue_01)
        {
            this.gameObject.GetComponent<Upturn>().enabled = false;
        }
        */
        UpFirenums();
    }

    // Update is called once per frame
    void UpFirenums()
    {
        for(int num = 0; num < firenum; num++)
        {
            Firepos = new Vector3(0.0f,130 + a * num, 0.0f);
            var UpImage = Instantiate(fire, Vector3.zero, Quaternion.identity, GameObject.Find("Canvas").transform);
            UpImage.GetComponent<RectTransform>().anchoredPosition = Firepos;
            UpFires.Add(UpImage);
        }
    }
}
