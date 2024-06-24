using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    private int score = 0;
    [SerializeField] TextMeshProUGUI timeTxet;
    [SerializeField] private float leftTime = 30;
    //このstageCountはステージクリアごとに"インクリメント"してください
    public int stageCount = 1;
    //timeCountはステージクリアごとに"false"にしてください
    //次のステージが開始するときに"true"にしてください
    public bool timeCount = true;
    void Start()
    {
        SetScoreTxet();
    }
    void Update()
    {
        if (timeCount)
        {
            leftTime -= Time.deltaTime;
            timeTxet.text = "Time:" + Mathf.RoundToInt(leftTime);
            //lefttimeが0になったら止まるようにします
            if (leftTime <= 0)
            {
                timeCount = false;
                //ここはゲームオーバーの処理にも使えます
            }
        }
    }
    //この関数はステージをクリアするごとに利用してください
    public void AddScore()
    {
        score += Mathf.RoundToInt(leftTime) * stageCount;
        scoreText.text = "SCORE:" + score;
    }
    //スコア初期化用関数
    private void SetScoreTxet()
    {
        scoreText.text = "SCORE:" + score;
    }
}