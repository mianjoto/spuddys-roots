using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : BaseSingleton<SceneManager>
{
    public Scenes CurrentScene;
    [SerializeField] GameObject _mainCameraPrefab;
    
    const string MAIN_CAMERA_TAG = "MainCamera";
    Camera _currentMainCamera;

    protected override void Awake()
    {
        base.Awake();
        _currentMainCamera = GameObject.FindWithTag(MAIN_CAMERA_TAG).GetComponent<Camera>();
        
        if (_currentMainCamera != null) return;
        
        _currentMainCamera = Instantiate(_mainCameraPrefab).GetComponent<Camera>();
        _currentMainCamera.tag = MAIN_CAMERA_TAG;
        _currentMainCamera.gameObject.SetActive(true);
        _currentMainCamera.enabled = true;
    }

    public void SwitchToScene(Scenes scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene.ToString());
        CurrentScene = scene;
        
        if (_currentMainCamera == null && _currentMainCamera.gameObject == null)        
            _currentMainCamera = Instantiate(_mainCameraPrefab).GetComponent<Camera>();
        
        _currentMainCamera.GetComponent<Camera>().tag = MAIN_CAMERA_TAG;
        _currentMainCamera.GetComponent<Camera>().enabled = true;
        _currentMainCamera.gameObject.SetActive(true);
    }

    public static void ClickToScene(Scenes scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene.ToString());
    }
}

public enum Scenes
{
    Title,
    Controls,
    Level_1,
    Level_2,
    GameOver,
    Win
}

