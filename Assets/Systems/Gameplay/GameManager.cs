using UnityEngine;

public class GameManager : BaseSingleton
{
    public static bool IsPaused { get; private set; }

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
}
