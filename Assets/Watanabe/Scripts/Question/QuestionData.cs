using UnityEngine;

[CreateAssetMenu(fileName = "QuestionData", menuName = "ScriptableObjects/CreateQuestionData")]
public class QuestionData : ScriptableObject
{
    [SerializeField]
    private string _viewQuestion = default;
    [SerializeField]
    private string _answerText = default;
    [SerializeField]
    private AudioClip _se = default;

    public string Answer => _answerText;
    public AudioClip SE => _se;
}
