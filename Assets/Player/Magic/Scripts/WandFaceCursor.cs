using UnityEngine;

public class WandFaceCursor : MonoBehaviour
{
    [SerializeField] int _rotationOffset = 270;
    Transform _transform;

    void Awake() => _transform = transform;
    void Update() => FaceCursor();

    void FaceCursor()
    {
        Vector3 mousePosition = InputListener.MousePositionInWorld;
        var direction = (mousePosition - _transform.position).normalized;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle += _rotationOffset; // Offset to face the right direction
        _transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
