using UnityEngine;

public class Toggle : MonoBehaviour
{
    [SerializeField]
    private JsonData _jsonData;
    [SerializeField]
    private Mouse    _mouse;

    public void OnTggleChanged()
    {
        if(_jsonData.overWriteSave)
            _jsonData.overWriteSave=false;
        else
            _jsonData.overWriteSave=true;
    }
    public void OnRopeChanged()
    {
        if (_mouse.isRope)
            _mouse.isRope = false;
        else
            _mouse.isRope = true;
    }
}
