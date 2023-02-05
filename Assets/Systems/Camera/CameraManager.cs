using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : BaseSingleton
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Vector3 cameraOffset;
    [SerializeField] float _cameraDampSmoothTime = 0.1f;
    Transform cameraTransform;
    
    float _initialCameraZPosition;

    Vector3 _cameraFollowVelocity = Vector3.zero;

    protected override void Awake()
    {
        base.Awake();
        cameraTransform = Camera.main.transform;
    }

    void Start() => _initialCameraZPosition = cameraTransform.position.z;
    void Update() => FollowPlayer();

    void FollowPlayer()
    {
        var targetPosition = playerTransform.position;
        targetPosition += cameraOffset;
        targetPosition = new Vector3(targetPosition.x, targetPosition.y, _initialCameraZPosition);
        
        cameraTransform.position = Vector3.SmoothDamp(cameraTransform.position, targetPosition, ref _cameraFollowVelocity, _cameraDampSmoothTime);
    }
}
