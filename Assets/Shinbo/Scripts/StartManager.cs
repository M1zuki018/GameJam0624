using UnityEngine;

/// <summary>
/// ①シーンが読み込まれたら、遊び方説明が表示されている状態
/// ②エンターキーが押されたら、遊び方説明を非表示にする
/// ③ゲーム開始
/// </summary>

public class StartManager : MonoBehaviour
{
    GameObject _explanationPanel;

    private void Awake()
    {
        _explanationPanel = GameObject.Find("ExplanationPanel");
    }

    // Start is called before the first frame update
    void Start()
    {
        _explanationPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameStart();
        }
    }

    void GameStart()
    {
        Debug.Log("ゲームスタート");
        //ゲーム開始の関数をここから呼べるようにする
        Destroy(_explanationPanel);
        Destroy(gameObject);
    }
}
