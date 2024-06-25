using System.Collections;
using UnityEngine;

public class QuestionMove : MonoBehaviour
{
    private Transform _tf;
    public static bool IsGameOver;
    private bool _expansionFlag;

    private void Start()
    {
        _tf = gameObject.transform;
        _tf.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        StartCoroutine(Expansion());
    }

    IEnumerator Expansion()
    {
        while (!_expansionFlag)
        {
            _tf.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            yield return new WaitForSeconds(0.05f);

            if (Mathf.Approximately(_tf.localScale.x, 1f)) { _expansionFlag = true; }
        }

        while (_expansionFlag)
        {
            _tf.localScale += new Vector3(0.05f, 0.05f, 0.05f);
            yield return new WaitForSeconds(0.3f);

            if (Mathf.Approximately(_tf.localScale.x, 2f))
            {
                _expansionFlag = false;
                Debug.Log("ゲームオーバー");
                IsGameOver = true;
                yield break;
            }
        }
    }
}
