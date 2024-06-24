using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �@ゲームスタートがオンになったら生成する
/// �A消えたらもう一回
/// �Bゲームオーバーになったらシーン遷移
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _questionObj;
    private Question _currentQuestion = default;

    public Question CurrentQuestion
    {
        get
        {
            return _currentQuestion;
        }
    }

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    // Update is called once per frame
    private void Update()
    {
        if (StartManager.IsGameStart == true)
        {
            if (GameObject.FindWithTag("Question") == null)
            {
                Spawn();
            }
        }

        if (QuestionMove.IsGameOver == true)
        {
            SceneManager.LoadScene("SampleScene");
            QuestionMove.IsGameOver = false;
        }
    }

    private void Spawn()
    {
        var go = Instantiate(_questionObj[Random.Range(0, _questionObj.Length)]);
        _currentQuestion = go.GetComponent<Question>();
    }
}
