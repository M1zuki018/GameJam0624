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
    public void Determination() //決定時のME
    {
        _sourse.PlayOneShot(_seClip[0]);
    }

    public void CursorMovement() //カーソル移動のME
    {
        _sourse.PlayOneShot(_seClip[1]);
    }

    public void Minecart() //トロッコの音
    {
        _sourse.PlayOneShot(_seClip[2]);
    }

    public void QuestionDestroyedSE(AudioClip _se)
    {
        _sourse.PlayOneShot(_se);
    }

    /*
    public void EarthenWallDestroyed() //土の壁が崩れた時に鳴るの音
    {
        _sourse.PlayOneShot(_seClip[3]);
    }
    public void FlowersWither() //花の壁が枯れた時に鳴る音
    {
        _sourse.PlayOneShot(_seClip[4]);
    }
    public void IceMelts() //氷の壁が解けた時に鳴る音
    {
        _sourse.PlayOneShot(_seClip[5]);
    }
    public void BlowOffGas() //ガスを吹き飛ばしたときに鳴る音
    {
        _sourse.PlayOneShot(_seClip[6]);
    }
    public void DestroyedStoneWall() //石の壁を破壊したときに鳴る音
    {
        _sourse.PlayOneShot(_seClip[7]);
    }
    public void CutChain() //鎖の壁をきった時に鳴る音
    {
        _sourse.PlayOneShot(_seClip[8]);
    }
    public void BurnedWoodenWall() //木の壁を燃やしたときに鳴る音
    {
        _sourse.PlayOneShot(_seClip[9]);
    }
    public void AteWallCake() //ケーキの壁を食べた時に鳴る音
    {
        _sourse.PlayOneShot(_seClip[10]);
    }
    public void PushedAsidePileRublle() //がれきの壁が崩れた時に鳴る音
    {
        _sourse.PlayOneShot(_seClip[11]);
    }

    public void StoneWallCollapsed() //石垣の壁が崩れた時に鳴る音
    {
        _sourse.PlayOneShot(_seClip[12]);
    }
    */

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
