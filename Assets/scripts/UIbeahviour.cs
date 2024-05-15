using UnityEngine;

public class UIBehaviour : MonoBehaviour
{
    Vector2 defaultSize;
    RectTransform rectTransform;

    float highlightedSize = .1f;
    float scaleSpeed = .35f;

    void Start()
    {
        // Get the RectTransform component
        rectTransform = GetComponent<RectTransform>();

        // Store the default size
        defaultSize = rectTransform.localScale;
    }

    public void OnPointerEnter()
    {
        
        // Scale the UI element to the highlighted size over time
        LeanTween.scale(rectTransform, new Vector2(defaultSize.x+ highlightedSize, defaultSize.y+ highlightedSize), scaleSpeed).setEaseOutBack();
    }

    public void OnPointerExit()
    {
        // Scale the UI element back to its default size over time
        LeanTween.scale(rectTransform, defaultSize, scaleSpeed).setEaseOutBack();
    }
}
