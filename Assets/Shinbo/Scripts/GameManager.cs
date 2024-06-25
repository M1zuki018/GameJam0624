using System.Collections;
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
    private SceneType _loadScene = SceneType.Result;
    [SerializeField]
    private ScoreManager _scoreManager = default;
    [SerializeField]
    private RectTransform _gameCanvas = default;
    [SerializeField] private GameObject[] _questionObj;
    [SerializeField] private GameObject _fadeOut;
    [SerializeField] public AudioClip CollisionSE;

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
    public ScoreManager ScoreManager => _scoreManager;

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
            StartCoroutine(FinishPerformance());
        }
    }

    private void Spawn()
    {
        var go = Instantiate(_questionObj[Random.Range(0, _questionObj.Length)]);
        var rect = go.GetComponent<RectTransform>();
        rect.parent = _gameCanvas;
        rect.SetAsFirstSibling();
        rect.localPosition = Vector3.zero;
        _currentQuestion = go.GetComponent<Question>();
    }
    IEnumerator FinishPerformance()
    {
        //UI

        yield return new WaitForSeconds(5);

        _fadeOut.SetActive(true);

        yield return new WaitForSeconds(2);
        
        SceneManager.LoadScene(_sceneNameDict[_loadScene]);
        //SceneManager.LoadScene(_sceneNameDict[SceneType.Result]);
        QuestionMove.IsGameOver = false;
    }
}


public enum SceneType
{
    Title,
    InGame,
    Result
}
