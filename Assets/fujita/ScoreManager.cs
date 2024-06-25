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
    private int _baseScore = 0;
    private int _score = 0;

    //SE関係
    [SerializeField] public AudioClip _countdownRemainingSe;
    [SerializeField] public AudioClip _gameOverSe;
    [SerializeField] public AudioClip _gameClearSe;
    private SE _sePlayer;
    private bool _onePlay;

    public float SolveTime => _solveTime;
    protected int TotalScore
    {
        get => _score;
        private set
        {
            _score = value;
            SetScoreText(value);
        }
    }

    public int StageCount => _stageCount;

    private void Start()
    {
        TotalScore = 0;
        _timer = _solveTime;
        _sePlayer = FindObjectOfType<SE>();
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

            if (_timer <= 5 && !_onePlay)
            {
                _sePlayer.QuestionDestroyedSE(_countdownRemainingSe);
                _onePlay = true;
            }

            if (_timer <= 0)
            {
                _isTimeCount = false;
                _sePlayer.QuestionDestroyedSE(_gameOverSe);
                //ここはゲームオーバーの処理にも使えます
            }
        }
    }

    /// <summary> 1問クリアしたら呼び出す関数 </summary>
    public void AddScore()
    {
        _sePlayer.QuestionDestroyedSE(_gameClearSe);

        //クリア数を加算して、スコアを更新
        _stageCount++;
        _baseScore += (GameManager.Instance.CurrentQuestion.GetQuestionScore() - Mathf.RoundToInt(_timer));

        TotalScore = _baseScore * _stageCount;

        _isTimeCount = false;
        _timer = _solveTime;
    }

    /// <summary> スコアの表示を更新する関数 </summary>
    private void SetScoreText(float value)
    {
        scoreText.text = value.ToString();
    }

    //leftTimeリセット用関数
    public void ResetleftTime()
    {
        //この数値は制限時間にあわせて変更してください
        _timer = 30;
    }
}
