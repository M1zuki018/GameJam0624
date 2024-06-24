using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    int _score;
    string[] _rankingText = { "ランキング1位", "ランキング2位", "ランキング3位", "ランキング4位", "ランキング5位" };
    int[] _rankingValue = new int[5];

    [SerializeField, Header("ランキングを表示させるテキストエリア")]
    Text[] _rankingField = new Text[5];

    // Use this for initialization
    void Start()
    {
        GetRanking();

        _score = 300; //スコアを取得
        //デバッグ用　point = 300;

        SetRanking(_score);

        for (int i = 0; i < _rankingField.Length; i++)
        {
            int x = i + 1;
            _rankingField[i].text = (x + (": ") + _rankingValue[i].ToString() + "点");
        }
    }

    /// <summary>
    /// ランキング呼び出し
    /// </summary>
    void GetRanking()
    {
        //ランキング呼び出し
        for (int i = 0; i < _rankingText.Length; i++)
        {
            _rankingValue[i] = PlayerPrefs.GetInt(_rankingText[i]);
        }
    }
    /// <summary>
    /// ランキング書き込み
    /// </summary>
    void SetRanking(int value)
    {
        //書き込み用
        for (int i = 0; i < _rankingText.Length; i++)
        {
            //取得した値とRankingの値を比較して入れ替え
            if (value > _rankingValue[i])
            {
                var change = _rankingValue[i];
                _rankingValue[i] = value;
                value = change;
            }
        }

        //入れ替えた値を保存
        for (int i = 0; i < _rankingText.Length; i++)
        {
            PlayerPrefs.SetInt(_rankingText[i], _rankingValue[i]);
        }
    }
}