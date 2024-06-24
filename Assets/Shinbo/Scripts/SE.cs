using UnityEngine;

/// <summary>
/// SEを鳴らしたい時に別のスクリプトから対応する関数を呼び出すようにする
/// </summary>
public class SE : MonoBehaviour
{
    [SerializeField] AudioClip[] _seClip;
    AudioSource _sourse;

    // Start is called before the first frame update
    void Start()
    {
        _sourse = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Correct()
    {
        _sourse.PlayOneShot(_seClip[0]);
    }
}
