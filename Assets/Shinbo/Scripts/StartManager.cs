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
    [SerializeField] private int _startWait = 5;

    public static bool IsGameStart = false;

    [SerializeField] public AudioClip _minecartSe;
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
        _sePlayer.QuestionDestroyedSE(_minecartSe);
        _explanationPanel.SetActive(false);
        StartCoroutine(StartingPerformance());
    }

    IEnumerator StartingPerformance()
    {
        yield return new WaitForSeconds(_startWait);
        Debug.Log("ゲームスタート");
        IsGameStart = true;
        gameObject.SetActive(false);
    }
}
