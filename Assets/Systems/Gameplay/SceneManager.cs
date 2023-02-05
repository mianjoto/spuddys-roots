using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : BaseSingleton<SceneManager>
{
    public Scenes CurrentScene;
    [SerializeField] GameObject _mainCameraPrefab;
    
    const string MAIN_CAMERA_TAG = "MainCamera";
    Camera _currentMainCamera;

    void Awake()
    {
        _currentMainCamera = GameObject.FindWithTag(MAIN_CAMERA_TAG).GetComponent<Camera>();
        
        if (_currentMainCamera != null) return;
        
        _currentMainCamera = Instantiate(_mainCameraPrefab).GetComponent<Camera>();
        _currentMainCamera.tag = MAIN_CAMERA_TAG;
        _currentMainCamera.gameObject.SetActive(true);
        _currentMainCamera.enabled = true;
    }

    public void SwitchToScene(Scenes scene)
    {
        if (_currentMainCamera != null)
            Destroy(_currentMainCamera);
        else
        {
            _currentMainCamera = GameObject.FindWithTag(MAIN_CAMERA_TAG).GetComponent<Camera>();
            Destroy(_currentMainCamera.gameObject);
        }


        UnityEngine.SceneManagement.SceneManager.LoadScene(scene.ToString());
        CurrentScene = scene;
        
        if (_currentMainCamera == null)        
            _currentMainCamera = Instantiate(_mainCameraPrefab).GetComponent<Camera>();
        
        _currentMainCamera.GetComponent<Camera>().tag = MAIN_CAMERA_TAG;
        _currentMainCamera.GetComponent<Camera>().enabled = true;
        _currentMainCamera.gameObject.SetActive(true);
    }
}

public enum Scenes
{
    Title,
    Level_1,
    Level_2,
    GameOver,
    Win
}

