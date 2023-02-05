using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenForClickToTransitionScene : MonoBehaviour
{
    [SerializeField] Scenes sceneToTransitionTo;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.ClickToScene(sceneToTransitionTo);
        }
    }
}
