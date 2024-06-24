using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ①ゲームスタートがオンになったら生成する
/// ②消えたらもう一回
/// ③ゲームオーバーになったらシーン遷移
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
