using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour
{
    [SerializeField] private Text _text = default;
    [SerializeField] public InputField _inputField = default;

    private string _preservation;
    private Transform _tf;

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
            YourFunction();
        }
    }

    private void YourFunction()
    {
        // Enterキーが押された時に実行するコード
        Debug.Log("EnterTrue");
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

        if (_inputField.text == _preservation)
        {
            Debug.Log("True");
        }
        else
        {
            Debug.Log($"{_text.text}");
            Debug.Log("false");
        }
    }
}
