using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class SwitchToSceneDetector : MonoBehaviour
{
    [SerializeField] Scenes _sceneToSwitchTo;
    
    Collider2D _sceneSwitchTrigger;

    const string PLAYER_TAG = "Player";

    void Awake()
    {
        if (_sceneSwitchTrigger != null) return;

        _sceneSwitchTrigger = GetComponent<Collider2D>();
        _sceneSwitchTrigger.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(PLAYER_TAG)) SceneManager.Instance.SwitchToScene(_sceneToSwitchTo);
    }

}
