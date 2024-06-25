using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text timeText;
    [Tooltip("1問あたりの時間")]
    [SerializeField]
    private float _solveTime = 30f;

    private float _timer = 0f;
    /// <summary> ステージプレイ中 -> true, クリア時 -> false </summary>
    private bool _isTimeCount = true;
    /// <summary> クリアした問題の数 </summary>
    private int _stageCount = 0;
    private int _score = 0;

    protected int Score
    {
        get => _score;
        private set
        {
            _score = value;
            SetScoreText();
        }
    }

    public int StageCount => _stageCount;

    private void Start()
    {
        Score = 0;
        _timer = _solveTime;
    }

    private void Update()
    {
        //ゲーム開始していなかったら計測しない
        if (!StartManager.IsGameStart) { return; }

        if (_isTimeCount)
        {
            _timer -= Time.deltaTime;
            timeText.text = Mathf.RoundToInt(_timer).ToString();
            //lefttimeが0になったら止まるようにします
            if (_timer <= 0)
            {
                _isTimeCount = false;
                //ここはゲームオーバーの処理にも使えます
            }
        }
    }

    /// <summary> 1問クリアしたら呼び出す関数 </summary>
    public void AddScore()
    {
        //クリア数を加算して、スコアを更新
        _stageCount++;
        Score += Mathf.RoundToInt(_timer) * _stageCount;

        _isTimeCount = false;
        _timer = _solveTime;
    }

    /// <summary> スコアの表示を更新する関数 </summary>
    private void SetScoreText()
    {
        scoreText.text = _score.ToString();
    }

    //leftTimeリセット用関数
    public void ResetleftTime()
    {
        //この数値は制限時間にあわせて変更してください
        _timer = 30;
    }
}
