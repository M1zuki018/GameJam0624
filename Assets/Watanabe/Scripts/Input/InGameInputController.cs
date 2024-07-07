using System;
using UnityEngine;
using UnityEngine.UI;

public class InGameInputController : MonoBehaviour
{
    [SerializeField]
    private StageImageController _stageImageController = default;
    [SerializeField]
    private Text _inputText = default;
    [SerializeField]
    private SE _sePlayer = default;
    [SerializeField]
    private AudioClip _answerTrueAudio = default;
    [SerializeField]
    private AudioClip _answerFalseAudio = default;

    private InputHandler _inputHandler = default;

    private void Start()
    {
        _inputHandler = new(new Action[]
        {
            () => _inputText.text = _inputHandler.GetCurrentInput()
        });
    }

    private void Update()
    {
        _inputHandler.OnUpdate();

        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckCorrect();
            _inputHandler.ClearInput();
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            _inputHandler.RemoveInput();
        }
    }

    private void CheckCorrect()
    {
        var currentInput = _inputHandler.GetCurrentInput();
        if (currentInput == "") { return; }

        if (GameManager.Instance.CurrentQuestion.CheckAnswer(currentInput))
        {
            _sePlayer.QuestionDestroyedSE(GameManager.Instance.CurrentQuestion.GetSE());
            GameManager.Instance.ScoreManager.AddScore();
            _stageImageController.Correct(GameManager.Instance.ScoreManager.StageCount);
            _sePlayer.QuestionDestroyedSE(_answerTrueAudio);

            Destroy(GameManager.Instance.CurrentQuestion.gameObject);
        }
        else
        {
            _sePlayer.QuestionDestroyedSE(_answerFalseAudio);
        }
    }
}
