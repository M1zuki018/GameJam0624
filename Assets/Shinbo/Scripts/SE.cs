using UnityEngine;

/// <summary>
/// SE��炵�������ɕʂ̃X�N���v�g����Ή�����֐����Ăяo���悤�ɂ���
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
