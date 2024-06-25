using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Cursor _cursor = default;

    private bool _ranking = false;

    public bool Ranking
    {
        get => _ranking;
        private set
        {
            _ranking = value;
            _cursor.ButtonEnabled(!value);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("enter");
        Ranking = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("exit");
        Ranking = false;
    }
}
