using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

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
        if (!_isFadeIn)
        {
            if (!_rankingField.Ranking) //ランキングがtrueなら、ランキングの操作を行う
            {
                CorsorMove();
                Select();
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

        transform.position = _button[_index].position;
    }

    private void Select()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(_index == 0) //リトライのシーン遷移
            {
                Invoke("Retry", 2);
            }
            else //タイトル画面のシーン遷移
            {
                Invoke("Title", 2);
            }
            _sePlayer.QuestionDestroyedSE(_determinationSe);
            _fadePanel.SetActive(true);
        }
    }

    private void Retry()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void Title()
    {
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

        _isFadeIn =false;
    }
}
