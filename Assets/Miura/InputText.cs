using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour
{
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
            // ここで任意の関数を呼び出します
            Enter();
        }
    }

    private void Enter()
    {
        // Enterキーが押された時に実行するコード
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
        }
        else
        {
            Debug.Log("false");
        }
    }
}
