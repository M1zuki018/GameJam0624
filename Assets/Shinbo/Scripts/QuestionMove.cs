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

    private RectTransform _tf;
    public static bool IsGameOver;
    
    private AudioClip _collisionSe;
    private SE _sePlayer;

    private void Start()
    {
        _solveTime = GameManager.Instance.ScoreManager.SolveTime;

        _collisionSe = GameManager.Instance.CollisionSE;
        _sePlayer = FindObjectOfType<SE>();
        _tf = gameObject.GetComponent<RectTransform>();
        _tf.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        StartCoroutine(Expansion());
    }

    private IEnumerator Expansion()
    {
        while (_timer <= _rapidMoveTime)
        {
            _timer += Time.deltaTime;
            var elapsed = Time.deltaTime / _rapidMoveTime;

            _tf.localScale += Vector3.one * elapsed;
            yield return null;
        }

        while (_timer <= _solveTime && !Mathf.Approximately(_tf.localScale.x, _finalScale))
        {
            _timer += Time.deltaTime;
            var elapsed = Time.deltaTime / _solveTime;

            _tf.localScale += Vector3.one * elapsed;

            yield return null;
        }

        Debug.Log("ゲームオーバー");
        _sePlayer.QuestionDestroyedSE(_collisionSe);
        IsGameOver = true;
        yield break;
    }
}
