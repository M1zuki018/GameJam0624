using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{
    [SerializeField] private Button[] _buttons = default;
    [SerializeField] private Transform[] _button;
    [SerializeField] private MouseOver _rankingField;
    private int _index;

    [SerializeField] public AudioClip _cursolSe;
    [SerializeField] public AudioClip _determinationSe;
    private SE _sePlayer;

    [SerializeField] private GameObject _fadePanel;

    private bool _isFadeIn;
    private bool _isFirst;
    private bool _isFadeOut;

    // Start is called before the first frame update
    void Start()
    {
        _buttons[_index].Select();

        _sePlayer = FindObjectOfType<SE>();
        transform.position = _button[0].position;

        StartCoroutine(FadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isFadeOut)
        {
            if (!_rankingField.Ranking) //ランキングがtrueなら、ランキングの操作を行う
            {
                CorsorMove();

                if (!_isFadeIn)
                {
                    Select();
                }
            }
        }
    }

    private void CorsorMove()
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
        //transform.position = _button[_index].position;
    }

    private void Select()
    {
        Debug.Log(_index);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!_isFirst)
            {
                if (_index == 0) //リトライのシーン遷移
                {
                    Invoke("Retry", 2);
                    _isFadeOut = true;
                }
                else if (_index == 1) //タイトル画面のシーン遷移
                {
                    Invoke("Title", 2);
                    _isFadeOut = true;
                }
                _sePlayer.QuestionDestroyedSE(_determinationSe);
                _fadePanel.SetActive(true);
                _isFirst = true;
            }
        }
    }

    private void Retry()
    {
        _isFadeOut = false;
        SceneManager.LoadScene("GameScene");
    }

    private void Title()
    {
        _isFadeOut = false;
        GameObject obj = GameObject.FindWithTag("BGM");
        Destroy(obj);
        SceneManager.LoadScene("TitleScene");
    }

    public void ButtonEnabled(bool flag)
    {
        foreach (var item in _buttons) { item.enabled = flag; }
    }

    IEnumerator FadeIn()
    {
        _isFadeIn = true;

        yield return new WaitForSeconds(2);

        _isFadeIn = false;
    }
}
