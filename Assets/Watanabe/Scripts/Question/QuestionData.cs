using UnityEngine;

[CreateAssetMenu(fileName = "QuestionData", menuName = "ScriptableObjects/CreateQuestionData")]
public class QuestionData : ScriptableObject
{
    [SerializeField]
    private string _viewQuestion = default;
    [SerializeField]
    private string _answerText = default;

    public string Answer => _answerText;
}
