using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour
{
    [SerializeField] private Text _text;
    private string _preservation;
    [SerializeField]public InputField _inputField;
    [SerializeField] private string _answer;
    [SerializeField] private string _question;

    private void value()
    {
       
        switch (_text.text)
        {
            case "AAA":
                _preservation = _answer;
                Debug.Log("switchTrue");
                break;
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
            // �����ŔC�ӂ̊֐����Ăяo���܂�
            YourFunction();
        }
    }

    private void YourFunction()
    {
        // Enter�L�[�������ꂽ���Ɏ��s����R�[�h
        Debug.Log("EnterTrue");
        value();
    }

}
