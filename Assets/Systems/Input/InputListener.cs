using System;
using UnityEngine;

public class InputListener : BaseSingleton
{
    [Header("Mouse Position")]
    public static Vector2 AbosluteMousePosition;
    public static Vector2 MousePositionInWorld;

    [Header("Key Bindings")]
    [SerializeField] KeyCode upKey = KeyCode.W;
    [SerializeField] KeyCode leftKey = KeyCode.A;
    [SerializeField] KeyCode downKey = KeyCode.S;
    [SerializeField] KeyCode rightKey = KeyCode.D;
    [SerializeField] KeyCode jumpKey = KeyCode.Space;
    [SerializeField] KeyCode interactKey = KeyCode.E;
    [SerializeField] KeyCode leftMouseButton = KeyCode.Mouse0;

    Camera _mainCamera;

    #region Key Down, Hold, Up Events
    public static Action OnUpKeyDown;
    public static Action OnLeftKeyDown;
    public static Action OnDownKeyDown;
    public static Action OnRightKeyDown;
    public static Action OnJumpKeyDown;
    public static Action OnInteractKeyDown;
    public static Action<GameObject> OnLeftMouseButtonDown;

    public static Action OnUpKeyHold;
    public static Action OnLeftKeyHold;
    public static Action OnDownKeyHold;
    public static Action OnRightKeyHold;
    public static Action OnJumpKeyHold;
    public static Action OnInteractKeyHold;
    public static Action<GameObject> OnLeftMouseButtonHold;

    public static Action OnUpKeyUp;
    public static Action OnLeftKeyUp;
    public static Action OnDownKeyUp;
    public static Action OnRightKeyUp;
    public static Action OnJumpKeyUp;
    public static Action OnInteractKeyUp;
    public static Action<GameObject> OnLeftMouseButtonUp;
    #endregion

    protected override void Awake()
    {
        base.Awake();
        _mainCamera = Camera.main;
    }

    void Update()
    {
        ListenForKeyDownEvents();
        ListenForKeyHoldEvents();
        ListenForKeyUpEvents();

        AbosluteMousePosition = Input.mousePosition;
        MousePositionInWorld = _mainCamera.ScreenToWorldPoint(AbosluteMousePosition);
        HandleMouseEvents();
    }

    void HandleMouseEvents()
    {
        if (!Input.GetKey(leftMouseButton)) return;

        GameObject clickedOnObject = GetObjectPlayerClickedOn();

        if (Input.GetKeyDown(leftMouseButton))
            OnLeftMouseButtonDown?.Invoke(clickedOnObject);
        if (Input.GetKey(leftMouseButton))
            OnLeftMouseButtonHold?.Invoke(clickedOnObject);
        if (Input.GetKeyUp(leftMouseButton))
            OnLeftMouseButtonUp?.Invoke(clickedOnObject);
        
    }

    GameObject GetObjectPlayerClickedOn()
    {
        GameObject clickedOnObject;
        Ray ray = _mainCamera.ScreenPointToRay(AbosluteMousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit.collider != null)
            clickedOnObject = hit.collider.gameObject;
        else
            clickedOnObject = null;
        
        return clickedOnObject;
    }

    void ListenForKeyDownEvents()
    {
        if (Input.GetKeyDown(upKey))
            OnUpKeyDown?.Invoke();
        if (Input.GetKeyDown(leftKey))
            OnLeftKeyDown?.Invoke();
        if (Input.GetKeyDown(downKey))
            OnDownKeyDown?.Invoke();
        if (Input.GetKeyDown(rightKey))
            OnRightKeyDown?.Invoke();
        if (Input.GetKeyDown(jumpKey))
            OnJumpKeyDown?.Invoke();
        if (Input.GetKeyDown(interactKey))
            OnInteractKeyDown?.Invoke();
    }

    void ListenForKeyHoldEvents()
    {
        if (Input.GetKey(upKey))
            OnUpKeyHold?.Invoke();
        if (Input.GetKey(leftKey))
            OnLeftKeyHold?.Invoke();
        if (Input.GetKey(downKey))
            OnDownKeyHold?.Invoke();
        if (Input.GetKey(rightKey))
            OnRightKeyHold?.Invoke();
        if (Input.GetKey(jumpKey))
            OnJumpKeyHold?.Invoke();
        if (Input.GetKey(interactKey))
            OnInteractKeyHold?.Invoke();
    }

    void ListenForKeyUpEvents()
    {
        if (Input.GetKeyUp(upKey))
            OnUpKeyUp?.Invoke();
        if (Input.GetKeyUp(leftKey))
            OnLeftKeyUp?.Invoke();
        if (Input.GetKeyUp(downKey))
            OnDownKeyUp?.Invoke();
        if (Input.GetKeyUp(rightKey))
            OnRightKeyUp?.Invoke();
        if (Input.GetKeyUp(jumpKey))
            OnJumpKeyUp?.Invoke();
        if (Input.GetKeyUp(interactKey))
            OnInteractKeyUp?.Invoke();
    }
    
}