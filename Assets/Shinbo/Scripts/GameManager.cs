using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �@�Q�[���X�^�[�g���I���ɂȂ����琶������
/// �A��������������
/// �B�Q�[���I�[�o�[�ɂȂ�����V�[���J��
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _questionObj;

    // Update is called once per frame
    private void Update()
    {
        if (StartManager.IsGameStart == true)
        {
            if (GameObject.FindWithTag("Question") == null)
            {
                Spawn();
            }
        }

        if (QuestionMove.IsGameOver == true)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void Spawn()
    {
        Instantiate(_questionObj[Random.Range(0, _questionObj.Length)]);
    }
}
