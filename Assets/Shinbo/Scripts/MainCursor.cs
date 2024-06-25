using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainCursor : MonoBehaviour
{
    [SerializeField]
    private Button[] _buttons = default;

    [SerializeField] private Transform[] _button;
    private int _index = 0;

    [SerializeField] private GameObject _panel;

    [SerializeField] Animator _fadeOut;

    [SerializeField] public AudioClip _cursolSe;
    [SerializeField] public AudioClip _determinationSe;
    private SE _sePlayer; 

    private bool _isCredit = false;

    // Start is called before the first frame update
    void Start()
    {
        _buttons[_index].Select();

        _sePlayer = FindObjectOfType<SE>();
        _panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Select();
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.W) && _index != 0)
        {
            _index--;
            _sePlayer.QuestionDestroyedSE(_cursolSe);
        }
        else if (Input.GetKeyDown(KeyCode.S) && _index != 1)
        {
            _index++;
            _sePlayer.QuestionDestroyedSE(_cursolSe);
        }
        _buttons[_index].Select();
    }

    private void Select()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (_index == 0) 
            {
                _fadeOut.gameObject.SetActive(true);
                Invoke("Scene", 2);
            }
            else
            {
                _panel.SetActive(true);
                CreditOpen();
            }
            _sePlayer.QuestionDestroyedSE(_determinationSe);
        }
    }

    private void Scene()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void CreditOpen() => _isCredit = true;

    public void CreditClose() => _isCredit = false;
}

