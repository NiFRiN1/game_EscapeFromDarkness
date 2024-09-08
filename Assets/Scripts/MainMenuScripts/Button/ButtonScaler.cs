using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float scaleFactor = 1.2f;

    private Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = originalScale * scaleFactor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originalScale;
    }

    public void ResetScale()
    {
        transform.localScale = originalScale;
    }
}
