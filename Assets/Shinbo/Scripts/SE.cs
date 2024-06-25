using UnityEngine;

/// <summary>
/// SEを鳴らしたい時に別のスクリプトから対応する関数を呼び出すようにする
/// </summary>
public class SE : MonoBehaviour
{
    [SerializeField] private AudioClip[] _seClip;
    private AudioSource _sourse;

    // Start is called before the first frame update
    private void Start()
    {
        _sourse = GetComponent<AudioSource>();
    }

    /// <summary>
    /// 正解したときに、正誤判定をとっているスクリプトから関数を呼んでください
    /// </summary>
    // Update is called once per frame


    public void Minecart() //トロッコの音
    {
        _sourse.PlayOneShot(_seClip[2]);
    }

    public void QuestionDestroyedSE(AudioClip _se)
    {
        _sourse.PlayOneShot(_se);
    }


    public void CorrectAnswer() //問題の正解時に鳴る音
    {
        _sourse.PlayOneShot(_seClip[13]);
    }

    public void IncorrectAnswer() //問題を不正解したときに鳴る音
    {
        _sourse.PlayOneShot(_seClip[14]);
    }

    public void CountdownRemaining() //問題回答制限時間が5秒になった時に鳴る音
    {
        _sourse.PlayOneShot(_seClip[15]);
    }

    public void SoundLettersBeingFired() //文字を発射した時に鳴る音
    {
        _sourse.PlayOneShot(_seClip[16]);
    }

    public void GameOver() //ゲームオーバー時に鳴る音
    {
        _sourse.PlayOneShot(_seClip[17]);
    }

    public void GameClear() //ゲームクリア時に鳴る音
    {
        _sourse.PlayOneShot(_seClip[18]);
    }
}
