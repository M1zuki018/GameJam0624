using System.Collections;
using UnityEngine;

public class CreditTextMove : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private float _waitSeconds = 5; //クレジットの秒数
    [SerializeField] private MainCursor _cursor;

    public void Set()
    {
        //StartCoroutine(TextEnd());
        Invoke("TextEnd", _waitSeconds);
    }
    private void TextEnd()
    {
        _cursor._isFirst = false;
        _panel.SetActive(false);
    }

    /*
    IEnumerator TextEnd()
    {
        Debug.Log("start");
        yield return new WaitForSeconds(_waitSeconds);
        //_cursor._isFirst = false;
        _panel.SetActive(false);
    }
    */
}
