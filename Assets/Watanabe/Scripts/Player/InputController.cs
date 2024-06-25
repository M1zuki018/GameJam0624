using UnityEngine;

public class InputController : MonoBehaviour
{
    private void Start()
    {
        var ui = FindObjectOfType<InGameUIController>();
        var inputField = ui.InputField;

        inputField.onEndEdit.AddListener(ApplyInput);
    }

    private void ApplyInput(string value)
    {

    }
}
