using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DetectEdgeOfLevel : MonoBehaviour
{
    CameraManager _cameraManager;
    const string PLAYER_TAG = "Player";

    void Start() => _cameraManager = Camera.main.GetComponent<CameraManager>();

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(PLAYER_TAG)) _cameraManager.IsFollowingPlayer = false;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(PLAYER_TAG)) _cameraManager.IsFollowingPlayer = true;
    }

}
