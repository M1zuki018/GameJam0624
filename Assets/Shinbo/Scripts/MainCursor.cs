using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCursor : MonoBehaviour
{
    [SerializeField] private Transform[] _button;
    private int _index;

    [SerializeField] private GameObject _panel;

    [SerializeField] Animator _fadeOut;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = _button[0].position;
        _panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CorsorMove();
        Select();
    }

    private void CorsorMove()
    {
        if (Input.GetKeyDown(KeyCode.W) && _index != 0)
        {
            _index--;
        }
        else if (Input.GetKeyDown(KeyCode.S) && _index != 1)
        {
            _index++;
        }

        transform.position = _button[_index].position;
    }

    private void Select()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (_index == 0) //リトライのシーン遷移
            {
                _fadeOut.gameObject.SetActive(true);
                Invoke("Scene", 2);
            }
            else
            {
                _panel.SetActive(true);
            }
        }
    }

    void Scene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

