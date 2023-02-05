using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Player Settings
    public const byte MAX_NUMBER_OF_LIVES = 3;
    const string OUT_OF_BOUNDS_TAG = "OutOfBounds";
    public byte CurrentLivesRemaining;
    #endregion

    public Transform LastActivatedRespawnPoint;

    #region Events
    public static Action<GameObject> OnLivesOver;
    public static Action<GameObject> OnPlayerRespawn;
    #endregion

    #region Components
    PlayerMovement _playerMovement;
    PlayerMagic _playerMagic;
    #endregion

    void Awake() => _playerMovement = GetComponent<PlayerMovement>();
    void Start() => InitializePlayer();
    void InitializePlayer() => CurrentLivesRemaining = MAX_NUMBER_OF_LIVES;

    public void TeleportToLastActivatedRespawnPoint()
    {
        _playerMovement.ResetVelocity();
        transform.position = LastActivatedRespawnPoint.position;
    }

    void TakeDamage()
    {
        if (CurrentLivesRemaining > 1)
        {
            CurrentLivesRemaining--;
            TeleportToLastActivatedRespawnPoint();
        }
        else
        {
            CurrentLivesRemaining = 0;
            OnLivesOver?.Invoke(this.gameObject);
        }
        Debug.Log("Player took damage. Lives remaining: " + CurrentLivesRemaining);
    }


    public void Respawn()
    {
        CurrentLivesRemaining = MAX_NUMBER_OF_LIVES;
        TeleportToLastActivatedRespawnPoint();
        gameObject.SetActive(true);

        OnPlayerRespawn?.Invoke(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(OUT_OF_BOUNDS_TAG))
        {
            TakeDamage();
        }
    }
}
