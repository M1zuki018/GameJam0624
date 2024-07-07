using System;
using UnityEngine;
using UnityEngine.UI;

public class InputDemo : MonoBehaviour
{
    [SerializeField]
    private Text _inputText = default;

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

        if (Input.GetKeyDown(KeyCode.Return)) { _inputHandler.ClearInput(); }
    }
}
