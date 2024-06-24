using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    [SerializeField] private MouseOver _rankPanel;
    private int _index;

    [SerializeField] private int _score;
    
    private string[] _rankingText = { "ランキング1位", "ランキング2位", "ランキング3位", "ランキング4位", "ランキング5位" };
    private int[] _rankingValue = new int[5];

    [SerializeField, Header("ランキングを表示させるテキストエリア")]
    private Text[] _rankingField;

    private string[] _rankingTextString = new string[5];

    // Use this for initialization
    private void Start()
    {
        GetRanking();

        //_score = _setRanking; //スコアを取得
        //デバッグ用　point = 300;

        SetRanking(_score);

        for(int i = 0; i < _rankingField.Length; i++)
        { 
            _rankingField[i].text = (i+1 + ": " + _rankingValue[i].ToString() + "点");
            _rankingTextString[i] = _rankingField[i].text;
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
        if (_rankPanel._ranking)
        {
            if (Input.GetKeyDown(KeyCode.S) && _index <= 1)
            {
                _index++;
            }
            else if (Input.GetKeyDown(KeyCode.W) && _index > 0)
            {
                _index--;
            }

            _rankingField[0].text = _rankingTextString[_index];
            _rankingField[1].text = _rankingTextString[_index + 1];
            _rankingField[2].text = _rankingTextString[_index + 2];

        }
    }
}