using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text timeText;
    [SerializeField] private float leftTime = 30;

    /// <summary> 1問あたりの時間 </summary>
    private float _solveTime = 0f;
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

    //timeCountはステージクリアごとに"false"にしてください
    //次のステージが開始するときに"true"にしてください
    public bool timeCount = true;

    private void Start()
    {
        Score = 0;
        _solveTime = leftTime;
    }

    private void Update()
    {
        //ゲーム開始していなかったら計測しない
        if (!StartManager.IsGameStart) { return; }

        //if (_isTimeCount)
        //{
        //    leftTime -= Time.deltaTime;
        //    timeText.text = "Time:" + Mathf.RoundToInt(leftTime);
        //    //lefttimeが0になったら止まるようにします
        //    if (leftTime <= 0)
        //    {
        //        _isTimeCount = false;
        //        leftTime = _solveTime;
        //        //ここはゲームオーバーの処理にも使えます
        //    }
        //}

        if (timeCount)
        {
            leftTime -= Time.deltaTime;
            timeText.text = Mathf.RoundToInt(leftTime).ToString();
            //lefttimeが0になったら止まるようにします
            if (leftTime <= 0)
            {
                timeCount = false;
                //ここはゲームオーバーの処理にも使えます
            }
        }
    }

    /// <summary> 1問クリアしたら呼び出す関数 </summary>
    public void AddScore()
    {
        //クリア数を加算して、スコアを更新
        _stageCount++;
        Score += Mathf.RoundToInt(leftTime) * _stageCount;

        _isTimeCount = false;
        leftTime = _solveTime;
    }

    /// <summary> スコアの表示を更新する関数 </summary>
    private void SetScoreText()
    {
        scoreText.text = _score.ToString();
    }
}