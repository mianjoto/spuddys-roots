using System;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    [SerializeField] KeyCode upKey = KeyCode.W;
    [SerializeField] KeyCode leftKey = KeyCode.A;
    [SerializeField] KeyCode downKey = KeyCode.S;
    [SerializeField] KeyCode rightKey = KeyCode.D;
    [SerializeField] KeyCode jumpKey = KeyCode.Space;
    [SerializeField] KeyCode interactKey = KeyCode.E;

    #region Key Down Events
    public static Action OnUpKeyDown;
    public static Action OnLeftKeyDown;
    public static Action OnDownKeyDown;
    public static Action OnRightKeyDown;
    public static Action OnJumpKeyDown;
    public static Action OnInteractKeyDown;
    #endregion

    #region Key Hold Events
    public static Action OnUpKeyHold;
    public static Action OnLeftKeyHold;
    public static Action OnDownKeyHold;
    public static Action OnRightKeyHold;
    public static Action OnJumpKeyHold;
    public static Action OnInteractKeyHold;
    #endregion

    #region Key Up Events
    public static Action OnUpKeyUp;
    public static Action OnLeftKeyUp;
    public static Action OnDownKeyUp;
    public static Action OnRightKeyUp;
    public static Action OnJumpKeyUp;
    public static Action OnInteractKeyUp;
    #endregion

    void Update()
    {
        ListenForKeyDownEvents();
        ListenForKeyHoldEvents();
        ListenForKeyUpEvents();
    }
    
    private void ListenForKeyDownEvents()
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

    private void ListenForKeyHoldEvents()
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

    private void ListenForKeyUpEvents()
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