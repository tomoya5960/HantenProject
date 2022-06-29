using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    public GameObject GOJ;
    public GameObject oya;
    [SerializeReference]
    public int printhonoo = 130;
    public float fps = 0.01f;
    public Sprite Image1;
    public Sprite Image2;
    public Sprite Image3;
    public Sprite Image4;
    public Sprite Image5;
    [SerializeReference]
    public Image logo;
    private bool loop = true;
    

    // Start is called before the first frame update
    void Start()
    {
        logo = GameObject.Find("Image").GetComponent<Image>();
        StartCoroutine("Sample");
    }
    void Hukusei()
    {
        
        Vector3 pos = new Vector3(0.0f, printhonoo, 0.0f);
        Instantiate(GOJ, pos, Quaternion.identity);
        GOJ.transform.parent = oya.transform;
        printhonoo += 130;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Sample()
    {
        while (loop == true)
        {
            yield return new WaitForSeconds(fps);
            GetComponent<Image>().sprite = Image2;

            yield return new WaitForSeconds(fps);
            GetComponent<Image>().sprite = Image3;

            yield return new WaitForSeconds(fps);
            GetComponent<Image>().sprite = Image4;

            yield return new WaitForSeconds(fps);
            GetComponent<Image>().sprite = Image5;

            yield return new WaitForSeconds(fps);
            GetComponent<Image>().sprite = Image1;


            yield return new WaitForSeconds(5);
            Hukusei();
        }
    }
}
