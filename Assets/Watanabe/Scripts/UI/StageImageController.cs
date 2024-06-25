using UnityEngine;
using UnityEngine.UI;

public class StageImageController : MonoBehaviour
{
    [Min(1)]
    [SerializeField]
    private int _stageCount = 1;
    [SerializeField]
    private GameObject _stageImagePrefab = default;
    [SerializeField]
    private Color _notClearedColor = Color.gray;
    [SerializeField]
    private Color _clearedColor = Color.white;

    private StageImage[] _stageImages = default;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        _stageImages = new StageImage[_stageCount];
        for (int i = 0; i < _stageCount; i++)
        {
            var cell = Instantiate(_stageImagePrefab);
            cell.transform.parent = transform;
            cell.name += i.ToString();

            cell.transform.GetChild(0).GetComponent<Text>().text = (i + 1).ToString();

            _stageImages[i] = cell.AddComponent<StageImage>();
            _stageImages[i].Initialize(cell.GetComponent<Image>(), _notClearedColor, _clearedColor);
        }
    }

    public void Correct(int index) => _stageImages[index - 1].IsCleared = true;
}

public class StageImage : MonoBehaviour
{
    private Image _image = default;
    private Color _notClearedColor = Color.gray;
    private Color _clearedColor = Color.white;
    private bool _isCleared = false;

    public bool IsCleared
    {
        get => _isCleared;
        set
        {
            _isCleared = value;
            _image.color = _isCleared ? _clearedColor : _notClearedColor;
        }
    }

    public void Initialize(Image image, Color notClearColor, Color clearColor)
    {
        _image = image;
        _notClearedColor = notClearColor;
        _clearedColor = clearColor;
        IsCleared = false;
    }
}
