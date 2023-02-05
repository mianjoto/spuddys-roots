using System;
using System.Collections;
using UnityEngine;

public class GameManager : BaseSingleton<GameManager>
{
    public static bool IsPaused { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        IsPaused = false;
    }

    void OnEnable()
    {
        PlayerManager.OnLivesOver += HandleGameOver;
    }

    void OnDisable()
    {
        PlayerManager.OnLivesOver -= HandleGameOver;
    }

    public static void TogglePauseGame()
    {
        if (IsPaused)
            UnPauseGame();
        else
            PauseGame();
    }

    public static void PauseGame()
    {
        IsPaused = true;
        Time.timeScale = 0;
    }

    public static void UnPauseGame()
    {
        IsPaused = false;
        Time.timeScale = 1;
    }

    public static void QuitGame()
    {
        Application.Quit();
    }

    void HandleGameOver(GameObject player)
    {
        StartCoroutine(TransitionToGameOverScene(player));
    }

    IEnumerator TransitionToGameOverScene(GameObject player)
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<PlayerMovement>().ResetVelocity();

        var mainCamera = Camera.main;
        var startingZoom = mainCamera.orthographicSize;
        var targetZoom = startingZoom - 5;

        while (mainCamera.orthographicSize > targetZoom)
        {
            mainCamera.orthographicSize -= 0.025f;
            yield return null;
        }

        

        while (player.GetComponent<SpriteRenderer>().color.a > 0)
        {
            var color = player.GetComponent<SpriteRenderer>().color;
            color.a -= 0.0008f;
            player.GetComponent<SpriteRenderer>().color = color;
            yield return null;
        }
        
        yield return new WaitForSeconds(1);
        SceneManager.ClickToScene(Scenes.GameOver);
        mainCamera.orthographicSize = startingZoom;
    }
}
