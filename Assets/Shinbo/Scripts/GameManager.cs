using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ①ゲームスタートがオンになったら生成する
/// ②消えたらもう一回
/// ③ゲームオーバーになったらシーン遷移
/// </summary>
public class GameManager : MonoBehaviour
{
    [Tooltip("問題数")]
    [Min(1)]
    [SerializeField]
    private int _questionCount = 1;
    [SerializeField]
    private ScoreManager _scoreManager = default;
    [SerializeField] private GameObject[] _questionObj;

    private readonly Dictionary<SceneType, string> _sceneNameDict = new()
    {
        { SceneType.Title, "TitleScene" },
        { SceneType.InGame, "GameScene" },
        { SceneType.Result, "ResultScene" }
    };

    private Question _currentQuestion = default;

    public Question CurrentQuestion
    {
        get
        {
            return _currentQuestion;
        }
    }

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        if (_scoreManager == null) { _scoreManager = FindObjectOfType<ScoreManager>(); }
    }

    // Update is called once per frame
    private void Update()
    {
        if (StartManager.IsGameStart)
        {
            if (GameObject.FindWithTag("Question") == null)
            {
                Spawn();
            }
        }

        if (QuestionMove.IsGameOver)
        {
            SceneManager.LoadScene("SampleScene");
            //SceneManager.LoadScene(_sceneNameDict[SceneType.Result]);
            QuestionMove.IsGameOver = false;
        }
    }

    private void Spawn()
    {
        var go = Instantiate(_questionObj[Random.Range(0, _questionObj.Length)]);
        _currentQuestion = go.GetComponent<Question>();
    }
}

public enum SceneType
{
    Title,
    InGame,
    Result
}
