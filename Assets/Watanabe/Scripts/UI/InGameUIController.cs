using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIController : MonoBehaviour
{
    [SerializeField]
    private InputField _inputField = default;
    [SerializeField]
    private Image _explainPanel = default;
    [SerializeField]
    private Text _scoreText = default;

    private bool _isGameStart = false;

    public InputField InputField => _inputField;
    public bool IsGameStart
    {
        get => _isGameStart;
        private set
        {
            _isGameStart = value;
            if (_isGameStart) { GameStart(); }
        }
    }

    private IEnumerator Start()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

        IsGameStart = true;
    }

    private void GameStart()
    {
#if UNITY_EDITOR
        Debug.Log("GameStart");
#endif
        _explainPanel.gameObject.SetActive(false);
    }
}
