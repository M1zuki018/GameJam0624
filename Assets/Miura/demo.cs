using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class demo : MonoBehaviour
{
    [SerializeField]
    private Button _button = default;
    [SerializeField]
    private InputField _input = default;

    private void Start()
    {
        _button.onClick.AddListener(() => Demo());
        _input.onSubmit.AddListener(AAA);
    }

    private void Demo() => Debug.Log("click");

    private void AAA(string value) { }
}
