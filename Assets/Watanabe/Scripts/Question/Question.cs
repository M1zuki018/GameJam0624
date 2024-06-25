using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    [SerializeField]
    private QuestionData _questionData = default;
    [SerializeField]
    private Text _text = default;

    private void Start()
    {
        if (_questionData == null)
        {
            Debug.LogError("問題データの割り当てがありません");
        }
        _text.text = _questionData.ViewQuestion;
    }

    public bool CheckAnswer(string input) => input == _questionData.Answer;

    public int GetQuestionScore() => _questionData.Score;

    public AudioClip GetSE() => _questionData.SE;
}
