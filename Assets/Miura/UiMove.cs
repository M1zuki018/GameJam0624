using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UiMove : MonoBehaviour
{
    private Transform _tf;
    bool i= true;
    private void Start()
    {
        _tf = gameObject.transform;
        _tf.localScale = new Vector3(1, 1, 1);
        StartCoroutine(Expansion());
    }
    private void Update()
    {
        if (_tf.localScale.x <= 0.0)
        {
            i = false;
        }
    }
    IEnumerator Expansion()
    {
        
        if (i)
        {  
            _tf.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
        }
       

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
