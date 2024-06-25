using System.Collections;
using UnityEngine;

public class QuestionMove : MonoBehaviour
{
    [SerializeField]
    private float _rapidMoveTime = 2f;
    [SerializeField]
    private float _finalScale = 2f;

    private float _timer = 0f;
    private float _solveTime = 0f;

    private Transform _tf;
    public static bool IsGameOver;

    private void Start()
    {
        _solveTime = GameManager.Instance.ScoreManager.SolveTime;

        _tf = gameObject.transform;
        _tf.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        StartCoroutine(Expansion());
    }

    private IEnumerator Expansion()
    {
        while (_timer <= _rapidMoveTime)
        {
            Debug.Log("rapid");
            _timer += Time.deltaTime;
            var elapsed = Time.deltaTime / _rapidMoveTime;

            _tf.localScale += Vector3.one * elapsed;
            yield return null;
        }

        while (_timer <= _solveTime)
        {
            Debug.Log("solve");
            var elapsed = Time.deltaTime / _solveTime;

            _tf.localScale += Vector3.one * elapsed;
            yield return null;
        }

        Debug.Log("ゲームオーバー");
        IsGameOver = true;
        yield break;
    }
}
