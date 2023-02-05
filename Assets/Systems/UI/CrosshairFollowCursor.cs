using UnityEngine;
using UnityEngine.UI;

public class CrosshairFollowCursor : MonoBehaviour
{
    public Image crosshairImage;
    RectTransform _rectTransform;

    void OnEnable() => Cursor.visible = false;
    void OnDisable() => Cursor.visible = true;
    
    private void Start() 
    {
        _rectTransform = crosshairImage.GetComponent<RectTransform>();
    }
    private void Update() => _rectTransform.position = InputListener.AbosluteMousePosition;
}