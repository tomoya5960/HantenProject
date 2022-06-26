using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    public float fps = 0.01f;
    public Sprite Image1;
    public Sprite Image2;
    public Sprite Image3;
    public Sprite Image4;
    public Sprite Image5;
    public Image honoo;
    private bool loop = true;

    // Start is called before the first frame update
    void Start()
    {
        honoo = GameObject.Find("hoono").GetComponent<Image>();
        StartCoroutine("Sample");
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
        }
    }
}
