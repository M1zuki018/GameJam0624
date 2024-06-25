using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour
{
    [SerializeField]
    private StageImageController _stageImageController = default;
    [SerializeField] private Text _text = default;
    [SerializeField] public InputField _inputField = default;
    public Ui _ui;
    private SE _sePlayer = default;

    void Start()
    {
        _sePlayer = FindObjectOfType<SE>();
        _inputField.onEndEdit.AddListener(EnterPressed);
    }
    void OnDestroy()
    {
        _inputField.onEndEdit.RemoveListener(EnterPressed);
    }

    private void EnterPressed(string text)
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            // �����ŔC�ӂ̊֐����Ăяo���܂�
            Enter();
        }
    }

    private void Enter()
    {
        // Enter�L�[�������ꂽ���Ɏ��s����R�[�h
        Debug.Log("EnterTrue");
        
       _ui.Move();
        value();
    }

    private void value()
    {
        //if (GameManager.Instance.CurrentQuestion.CheckAnswer(_inputField.text))
        //{
        //    Debug.Log("Answerture");
        //}

        if (_text.text == _inputField.text)
        {
            Debug.Log("Answerture");
            _sePlayer.QuestionDestroyedSE(GameManager.Instance.CurrentQuestion.GetSE());
            GameManager.Instance.ScoreManager.AddScore();
            _stageImageController.Correct(GameManager.Instance.ScoreManager.StageCount);
        }
        else
        {
            Debug.Log("false");
        }
    }
}
