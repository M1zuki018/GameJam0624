using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMove : MonoBehaviour
{
    private Transform _tf;
    private void Start()
    {
        _tf = gameObject.transform;
        _tf.localScale = new Vector3(1, 1, 1);
        StartCoroutine(Expansion());
    }
    IEnumerator Expansion()
    {
        _tf.localScale += new Vector3(-0.1f, -0.1f, -0.1f);

        yield return new WaitForSeconds(0.1f);

        if (Mathf.Approximately(_tf.localScale.x, 0))
        {
            yield break;
        }

        StartCoroutine(Expansion());
    }
    //RectTransform rect;

    //void Start()
    //{
    //    rect = GetComponent<RectTransform>();
    //}
    //private void Update()
    //{
    //    rect.localScale += new Vector3(0, 0, 0);
    //}
}
