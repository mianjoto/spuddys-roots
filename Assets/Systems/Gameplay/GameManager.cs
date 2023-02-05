using System.Collections;
using UnityEngine;

public class GameManager : BaseSingleton<GameManager>
{
    public static bool IsPaused { get; private set; }

    void Awake()
    {
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
        player.SetActive(false);

        // ADD SOME U.I. HERE TO SHOW GAME OVER SCREEN
        // AND THEN RESTART THE GAME
    }
    
}
