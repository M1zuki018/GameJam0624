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

    // Start is called before the first frame update
    private void Start()
    {
        _explanationPanel.SetActive(true);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameStart();
        }
    }

    private void GameStart()
    {
        Debug.Log("ゲームスタート");
        IsGameStart = true;
        //ゲーム開始の関数をここから呼べるようにする
        _explanationPanel.SetActive(false);
        gameObject.SetActive(false);
    }
}
