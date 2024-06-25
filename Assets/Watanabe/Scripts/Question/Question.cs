using UnityEngine;

public class Question : MonoBehaviour
{
    [SerializeField]
    private QuestionData _questionData = default;

    private void Start()
    {
        if (_questionData == null)
        {
            Debug.LogError("問題データの割り当てがありません");
        }
    }

    public bool CheckAnswer(string input) => input == _questionData.Answer;

    public AudioClip GetSE() => _questionData.SE;
}
