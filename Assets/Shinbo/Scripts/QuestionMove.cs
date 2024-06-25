using System.Collections;
using UnityEngine;

public class QuestionMove : MonoBehaviour
{
    private Transform _tf;
    public static bool IsGameOver;
    private bool _expansionFlag;

    // Start is called before the first frame update
    private void Start()
    {
        _tf = gameObject.transform;
        _tf.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        StartCoroutine(Expansion());
    }

    // Update is called once per frame
    private void Update()
    {
        if (Mathf.Approximately(_tf.localScale.x, 2f))
        {
            Debug.Log("ゲームオーバー");
            IsGameOver = true;
        }
    }

    IEnumerator Expansion()
    {

        if (Mathf.Approximately(_tf.localScale.x, 1f))
        {
            _expansionFlag = true;

        }

        if (_expansionFlag)
        {
            _tf.localScale += new Vector3(0.05f, 0.05f, 0.05f);
            yield return new WaitForSeconds(0.3f);

            if (Mathf.Approximately(_tf.localScale.x, 2f))
            {
                _expansionFlag = false;
                yield break;
            }

            StartCoroutine(Expansion());
        }
        else
        {
            _tf.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            yield return new WaitForSeconds(0.05f);
            StartCoroutine(Expansion());
        }

    }
}
