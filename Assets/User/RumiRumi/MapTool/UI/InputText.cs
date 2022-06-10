using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour
{
    public TMP_InputField Field;
    public JsonData       jsonData;

    public void OnEndEdit()
    {
        string Input = Field.GetComponent<TMP_InputField>().text;
        jsonData.fileName = Input;
    }
}
