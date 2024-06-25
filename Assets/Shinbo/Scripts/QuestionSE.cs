using UnityEngine;

public class QuestionSE : MonoBehaviour
{
    [SerializeField] public AudioClip _seClip;
    private GameObject _seObj;
    private SE _se;

    // Start is called before the first frame update
    private void Start()
    {
        _seObj = GameObject.FindWithTag("SE");
        _se = _seObj.GetComponent<SE>();
    }

    private void OnDisable()
    {
        _se.QuestionDestroyedSE(_seClip);
    }
}
