using System.Collections;
using UnityEngine;

public class CreditTextMove : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private int _waitSeconds = 5; //文字を送り終わった後の停止秒数
    [SerializeField] private float _textSpead = 0.003f; //文字を送る速さ

    // Update is called once per frame
    private void Update()
    {
        if (transform.localPosition.y >= -35)
        {
            StartCoroutine("TextEnd");
        }
        else
        {
            transform.Translate(0, _textSpead, 0);
        }
    }

    IEnumerator TextEnd()
    {
        yield return new WaitForSeconds(_waitSeconds);
        _panel.SetActive(false);
    }
}
