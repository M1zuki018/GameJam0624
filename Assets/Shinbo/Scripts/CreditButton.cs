using UnityEngine;

public class CreditButton : MonoBehaviour
{
    [SerializeField] private GameObject _creditPanel;

    private void Start()
    {
        _creditPanel.SetActive(false);
    }

    public void Credit()
    {
        _creditPanel.SetActive(true);
    }
}
