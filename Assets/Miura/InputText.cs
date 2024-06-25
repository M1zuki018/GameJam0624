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

    private Vector3 _initialPos = default;
    private float _uiTime;
    private bool _setActiveBool = true;


    [SerializeField] private AudioClip _answerTrue;
    [SerializeField] private AudioClip _answerFalse;
    [SerializeField] private AudioClip _answerShoot;
    private SE _sePlayervalue;

    void Start()
    {
        _sePlayer = FindObjectOfType<SE>();
        _inputField.onEndEdit.AddListener(EnterPressed);
        _sePlayervalue = FindObjectOfType<SE>();

        _initialPos = _rtf.localPosition;
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
        MovementLogic();
        //Invoke("uiSetActive", 0.5f);
        value();
    }

    private void value()
    {
        
        if (GameManager.Instance.CurrentQuestion.CheckAnswer(_inputField.text))
        {
            Debug.Log("Answerture");
            _sePlayer.QuestionDestroyedSE(GameManager.Instance.CurrentQuestion.GetSE());
            GameManager.Instance.ScoreManager.AddScore();
            _stageImageController.Correct(GameManager.Instance.ScoreManager.StageCount);
            _sePlayervalue.QuestionDestroyedSE(_answerTrue);
            Debug.Log("true");

            Destroy(GameManager.Instance.CurrentQuestion.gameObject);
        }
        else
        {
            _sePlayervalue.QuestionDestroyedSE(_answerFalse);
            Debug.Log("false");
            Invoke("UiReset", 0.3f);
        }
    }
    public void UiReset()
    {
        _rtf.localScale = Vector3.one;
        _rtf.localPosition = _initialPos;
        _inputField.text = "";
        _inputField.textComponent.text = "";
        Debug.Log(_rtf.localPosition);
        //uiSetActive();
    }

    public void uiSetActive()
    {
        gameObject.SetActive(_setActiveBool = !_setActiveBool);
        Debug.Log($"_uisetActive:{_setActiveBool}");
    }

    public void MovementLogic()
    {
        Debug.Log("Move");
        _sePlayervalue.QuestionDestroyedSE(_answerShoot);
        while (_rtf.localScale.x >= 0.5f)
        {
            _rtf.localScale -= new Vector3(0.1f, 0.1f,0.1f);
        }
    }
}


