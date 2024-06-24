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


        if (!_rankingField._ranking) //�����L���O��true�Ȃ�A�����L���O�̑�����s��
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
            if(_index == 0) //���g���C�̃V�[���J��
            {
                SceneManager.LoadScene("SampleScene");
            }
            else //�^�C�g����ʂ̃V�[���J��
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
