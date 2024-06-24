using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour
{
    [SerializeField] private Text _text=default;
    private string _preservation;
    [SerializeField]public InputField _inputField=default;
    private Transform _tf;
    private void value()
    {
        //if (GameManager.Instance.CurrentQuestion.CheckAnswer(_inputField.text))
        //{
        //    Debug.Log("Answerture");
        //}

        if (_text.text == _inputField.text)
        {
            Debug.Log("Answerture");
            
        }
     
        if (_inputField.text==_preservation)
        {
            Debug.Log("True");
        }
        else
        {
            Debug.Log($"{_text.text}");
            Debug.Log("false");
        }
    }

    void Start()
    {
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
}
