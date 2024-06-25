using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ui : MonoBehaviour
{
    [SerializeField]
    private RectTransform _rtf;
    [SerializeField]
    private GameObject _gameobj;
    private float _uiTime;
    private void Start()
    {
        UiReset();
    }
    private void UiReset()
    {
        _rtf.localScale = Vector3.one;
        _rtf.localPosition = Vector3.one;
        Debug.Log(_rtf.localPosition);
        _gameobj.SetActive(true);
    }

    public void Move()
    {
        Debug.Log("Move");
        while (_rtf.localScale.x >= 0.5f)
        {
            _rtf.localScale -= new Vector3(0.001f, 0.001f, 0.001f);
        }
        _uiTime += Time.time;
        Debug.Log(_uiTime);
        if (_uiTime >= 2)
        {
            Debug.Log("Time");
            _gameobj.SetActive(false);
        }
    }
}
