using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMagic : MonoBehaviour
{
    [SerializeField] Transform wandTransform;
    [SerializeField] Transform wandProjectileSpawnPoint;
    [SerializeField] SpriteRenderer wandTipSpriteRenderer;
    [SerializeField] List<ABC_Magic> magicList;
    
    MagicType _currentMagicType;
    ABC_Magic _currentMagic;

    float _currentCastCooldown;
    float _timeSinceLastCast = 999f;

    void OnEnable()
    {
        InputListener.OnInteractKeyDown += CycleWandMagicType;
        InputListener.OnCastKeyDown += CastMagic;
    }
    void OnDisable()
    {
        InputListener.OnInteractKeyDown -= CycleWandMagicType;
        InputListener.OnCastKeyDown -= CastMagic;  
    }

    void Start()
    {
        _currentMagicType = MagicType.Yellow;
    }

    void Update()
    {
        _timeSinceLastCast += Time.deltaTime;
    }

    private void CycleWandMagicType()
    {
        Color oldWandTipColor = wandTipSpriteRenderer.color;
        SwitchToNextMagicType();
        Color newWandTipColor = wandTipSpriteRenderer.color;
        StartCoroutine(ChangeWandTipColor(oldWandTipColor, newWandTipColor));
    }

    private void SwitchToNextMagicType()
    {
        switch (_currentMagicType)
        {
            case MagicType.Yellow:
                _currentMagicType = MagicType.Red;
                _currentMagic = magicList.Find(magic => magic.MagicData.MagicType == MagicType.Red);
                break;
            case MagicType.Red:
                _currentMagicType = MagicType.Blue;
                _currentMagic = magicList.Find(magic => magic.MagicData.MagicType == MagicType.Blue);
                break;
            case MagicType.Blue:
                _currentMagicType = MagicType.Green;
                _currentMagic = magicList.Find(magic => magic.MagicData.MagicType == MagicType.Green);
                break;
            case MagicType.Green:
                _currentMagicType = MagicType.Yellow;
                _currentMagic = magicList.Find(magic => magic.MagicData.MagicType == MagicType.Yellow);
                break;
        }
        _currentCastCooldown = _currentMagic.MagicData.CastCooldownInSeconds;
    }

    IEnumerator ChangeWandTipColor(Color oldWantTipColor, Color newWandTipColor)
    {
        // NOTE; TEMPORARY CODE TO TEST MAGIC CYCLING
        // NOTE; TEMPORARY CODE TO TEST MAGIC CYCLING
        // NOTE; TEMPORARY CODE TO TEST MAGIC CYCLING
        // NOTE; TEMPORARY CODE TO TEST MAGIC CYCLING
        float elapsedTime = 0f;
        float duration = 0.5f;

        switch (_currentMagicType)
        {
            case MagicType.Yellow:
                newWandTipColor = Color.yellow;
                break;
            case MagicType.Red:
                newWandTipColor = Color.red;
                break;
            case MagicType.Blue:
                newWandTipColor = Color.blue;
                break;
            case MagicType.Green:
                newWandTipColor = Color.green;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }


        while (elapsedTime < duration)
        {
            wandTipSpriteRenderer.color = Color.Lerp(oldWantTipColor, newWandTipColor, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    public void CastMagic()
    {
        Debug.Log("time since last cast: " + _timeSinceLastCast + " cast cooldown: " + _currentMagic.CastCooldown);
        if (_timeSinceLastCast < _currentCastCooldown)
            return;
        
        _currentMagic.Cast();
        _timeSinceLastCast = 0f;
    }
}

public enum MagicType
{
    Yellow,
    Red,
    Blue,
    Green
}