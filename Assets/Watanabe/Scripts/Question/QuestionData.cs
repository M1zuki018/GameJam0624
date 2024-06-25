using UnityEngine;

[CreateAssetMenu(fileName = "QuestionData", menuName = "ScriptableObjects/CreateQuestionData")]
public class QuestionData : ScriptableObject
{
    [SerializeField]
    private string _viewQuestion = default;
    [SerializeField]
    private string _answerText = default;
    [Tooltip("この問題の得点")]
    [SerializeField]
    private int _score = 100;
    [SerializeField]
    private AudioClip _se = default;

    public string Answer => _answerText;
    public int Score => _score;
    public AudioClip SE => _se;
}
