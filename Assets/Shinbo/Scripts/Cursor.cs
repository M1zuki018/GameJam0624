using UnityEngine;
using UnityEngine.SceneManagement;

public class Cursor : MonoBehaviour
{
    [SerializeField] private Transform[] _button;
    [SerializeField] private MouseOver _rankingField;
    private int _index;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = _button[0].position;
    }

    // Update is called once per frame
    void Update()
    {


        if (!_rankingField._ranking) //ランキングがtrueなら、ランキングの操作を行う
        {
            CorsorMove();
            Select();
        }
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
            if(_index == 0) //リトライのシーン遷移
            {
                SceneManager.LoadScene("SampleScene");
            }
            else //タイトル画面のシーン遷移
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
