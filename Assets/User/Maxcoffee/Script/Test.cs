using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Test : MonoBehaviour
{
    public Sprite imageB;
    public Sprite imageC;
    private Image myPhoto;
    [SerializeField]
    private float Time = 4.0f;
    public float KaitenTime = 0.001f;
    void Start()
    {
        myPhoto = GameObject.Find("Logo").GetComponent<Image>();
        myPhoto.sprite = imageB;
        StartCoroutine("Change");
    }
    IEnumerator Change()
    {
        while (true)
        {
            yield return new WaitForSeconds(Time);
            for (int turn = 0; turn < 90; turn++)
            {
                this.transform.Rotate(0, -1, 0);
                yield return new WaitForSeconds(KaitenTime);
            }
            myPhoto.sprite = imageC;
            for (int turn = 0; turn < 90; turn++)
            {
                this.transform.Rotate(0, -1, 0);
                yield return new WaitForSeconds(KaitenTime);
            }



            yield return new WaitForSeconds(Time);
            for (int turn = 0; turn < 90; turn++)
            {
                this.transform.Rotate(0, -1, 0);
                yield return new WaitForSeconds(KaitenTime);
            }
            myPhoto.sprite = imageB;
            for (int turn = 0; turn < 90; turn++)
            {
                this.transform.Rotate(0, -1, 0);
                yield return new WaitForSeconds(KaitenTime);
            }
        }
    }
}
