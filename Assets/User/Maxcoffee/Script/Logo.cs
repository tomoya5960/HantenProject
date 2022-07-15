using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logo : MonoBehaviour
{
    public float fps = 0.2f;
    public float read = 1.0f;
    public float MoveSpeed = 0.1f;
    public Sprite Image1;
    public Sprite Image2;
    public Sprite Image3;
    public Sprite Image4;
    public Sprite Image5;
    public Sprite Image6;
    [SerializeReference]
    public Image logo;
    public Transform startMarker; //現在の位置
    public Transform endMarker;
    private float distance_two;
    public float present_Location;
    private bool test;
    void Start()
    {
        logo = GameObject.Find("Image").GetComponent<Image>();
        StartCoroutine("Sample");
        distance_two = Vector3.Distance(startMarker.localPosition, endMarker.localPosition);

    }
    private void Update()
    {
        if (test && present_Location <= 1)
        {
            // 現在の位置
            present_Location = (Time.time * MoveSpeed) / distance_two;

            // オブジェクトの移動
            transform.localPosition = Vector3.Lerp(startMarker.localPosition, endMarker.localPosition, present_Location);
        }
    }

    // Update is called once per frame
    private IEnumerator Sample()
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
        GetComponent<Image>().sprite = Image6;

        yield return new WaitForSeconds(fps);
        GetComponent<Image>().sprite = Image6;

        yield return new WaitForSeconds(read);
        GetComponent<Image>().sprite = Image5;

        yield return new WaitForSeconds(fps);
        GetComponent<Image>().sprite = Image4;

        yield return new WaitForSeconds(fps);
        GetComponent<Image>().sprite = Image3;

        yield return new WaitForSeconds(fps);
        GetComponent<Image>().sprite = Image2;

        yield return new WaitForSeconds(fps);
        GetComponent<Image>().sprite = Image1;

        yield return new WaitForSeconds(fps);
        test = true;
    }
}