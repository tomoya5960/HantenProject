using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Migimuki : MonoBehaviour
{
    public float fps = 0.2f;
    public Sprite Image1;
    public Sprite Image2;
    public Sprite Image3;
    public Sprite Image4;
    public Sprite Image5;
    [HideInInspector]
    public Image honoo;

    private bool anime = true;

    void Start()
    {
        honoo = GameObject.Find("migi").GetComponent<Image>();
        StartCoroutine("Sample");
    }
    private void Update()
    {
    }

    // Update is called once per frame
    private IEnumerator Sample()
    {
        while (anime)
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
        }

    }
}