using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    [SerializeField] private MouseOver _rankPanel;

    [SerializeField] private int _score;

    [SerializeField, Header("ランキングを表示させるテキストエリア")]
    private Text[] _rankingField;

    private int _index;

    private readonly string[] _rankingText = { "ランキング1位", "ランキング2位", "ランキング3位", "ランキング4位", "ランキング5位" };
    private readonly int[] _rankingValue = new int[5];

    private void Start()
    {
        GetRanking();

        //_score = _setRanking; //スコアを取得
        //デバッグ用　point = 300;

        SetRanking(_score);

        for(int i = 0; i < _rankingField.Length; i++)
        { 
            _rankingField[i].text = $"{i + 1}: {_rankingValue[i]}点";
        }
    }

    /// <summary>
    /// ランキング呼び出し
    /// </summary>
    private void GetRanking()
    {
        //ランキング呼び出し
        for (int i = 0; i < _rankingText.Length; i++)
        {
            _rankingValue[i] = PlayerPrefs.GetInt(_rankingText[i]); //5位までとれている
        }
    }
    /// <summary>
    /// ランキング書き込み
    /// </summary>
    private void SetRanking(int value)
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

    private void Update()
    {
        if (_rankPanel.Ranking)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                //必要数を超えないように
                if (_index + 3 >= _rankingText.Length) { return; }

                _index++;
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                if (_index - 1 < 0) { return; }

                _index--;
            }

            _rankingField[0].text = $"{_index + 1}: {_rankingValue[_index]}点";
            _rankingField[1].text = $"{_index + 2}: {_rankingValue[_index + 1]}点";
            _rankingField[2].text = $"{_index + 3}: {_rankingValue[_index + 2]}点";
        }
    }
}