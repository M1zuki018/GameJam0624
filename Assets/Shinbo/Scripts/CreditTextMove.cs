using System.Collections;
using UnityEngine;

public class CreditTextMove : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private int _waitSeconds = 5; //クレジットの秒数

    private void Start()
    {
        StartCoroutine(TextEnd());
    }

    IEnumerator TextEnd()
    {
        yield return new WaitForSeconds(_waitSeconds);
        _panel.SetActive(false);
    }
}
