using System.Collections;
using UnityEngine;

/// <summary>
/// ①シーンが読み込まれたら、遊び方説明が表示されている状態
/// ②エンターキーが押されたら、遊び方説明を非表示にする
/// ③ゲーム開始
/// </summary>

public class StartManager : MonoBehaviour
{
    [SerializeField] private GameObject _explanationPanel;

    public static bool IsGameStart = false;

    [SerializeField] public AudioClip _determinationSe;
    private SE _sePlayer;

    // Start is called before the first frame update
    private IEnumerator Start()
    {
        _explanationPanel.SetActive(true);
        _sePlayer = FindObjectOfType<SE>();

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        GameStart();
    }

    private void GameStart()
    {
        Debug.Log("ゲームスタート");
        IsGameStart = true;
        _sePlayer.QuestionDestroyedSE(_determinationSe);
        _explanationPanel.SetActive(false);
        gameObject.SetActive(false);
    }
}
