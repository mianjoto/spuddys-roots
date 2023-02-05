using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : BaseSingleton
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] Transform playerTransform;
    [SerializeField] float cameraFollowSpeed = 10f;
    [SerializeField] float cameraFollowDistance = 10f;
    [SerializeField] float cameraFollowHeight = 10f;
    [SerializeField] float cameraFollowHeightDamping = 2f;
    [SerializeField] float cameraFollowRotationDamping = 3f;

    Vector3 _cameraFollowVelocity = Vector3.zero;
    Vector3 _cameraFollowRotationVelocity = Vector3.zero;

    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        Vector3 targetPosition = playerTransform.position;
        targetPosition -= playerTransform.forward * cameraFollowDistance;
        targetPosition.y += cameraFollowHeight;

        Vector3 currentPosition = Vector3.SmoothDamp(cameraTransform.position, targetPosition, ref _cameraFollowVelocity, cameraFollowSpeed * Time.deltaTime);

        cameraTransform.position = currentPosition;

        Quaternion currentRotation = cameraTransform.rotation;
        Quaternion targetRotation = Quaternion.LookRotation(playerTransform.position - cameraTransform.position);
        cameraTransform.rotation = Quaternion.Slerp(currentRotation, targetRotation, cameraFollowRotationDamping * Time.deltaTime);
    }
}
