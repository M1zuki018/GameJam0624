using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool _ranking;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("enter");
        _ranking = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("exit");
        _ranking = false;
    }
}
