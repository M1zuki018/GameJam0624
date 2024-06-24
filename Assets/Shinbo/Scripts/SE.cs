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
    public void Correct()
    {
        _sourse.PlayOneShot(_seClip[0]);
    }
}
