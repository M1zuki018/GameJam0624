using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour
{
    [SerializeField]
    private StageImageController _stageImageController = default;
    [SerializeField] private Text _text = default;
    [SerializeField] public InputField _inputField = default;
    private SE _sePlayer = default;

    [SerializeField]
    private RectTransform _rtf = default;
    [SerializeField]
    private GameObject _gameobj = default;

    private float _uiTime;
    private bool _setActiveBool = true;

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

        MovementLogic();
        Invoke("value",0.5f);
    }

    private void value()
    {
        if (GameManager.Instance.CurrentQuestion.CheckAnswer(_inputField.text))
        {
            Debug.Log("Answerture");
        }

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
            UiReset();
        }
    }
    public void UiReset()
    {
        _rtf.localScale = Vector3.one;
        _rtf.localPosition = Vector3.one;
        Debug.Log(_rtf.localPosition);
        uiSetActive();
    }

    public void uiSetActive()
    {
        _gameobj.SetActive(_setActiveBool = !_setActiveBool);
        Debug.Log($"_uisetActive:{_setActiveBool}");
    }

    public void MovementLogic()
    {
        Debug.Log("Move");

        while (_rtf.localScale.x >= 0.5f)
        {
            _rtf.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
        }
        Invoke("uiSetActive", 0.5f);
        Debug.Log("MOve");
        value();
    }
}


