using System.Collections;
using UnityEngine;

public class QuestionMove : MonoBehaviour
{
    private Transform _tf;
    public static bool IsGameOver;

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
        _tf.localScale += new Vector3(0.01f, 0.01f, 0.01f);

        yield return new WaitForSeconds(0.1f);

        if (Mathf.Approximately(_tf.localScale.x, 2f))
        {
            yield break;
        }

        StartCoroutine(Expansion());
    }
}
