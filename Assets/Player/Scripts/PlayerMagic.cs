using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMagic : MonoBehaviour
{
    [SerializeField] Transform wandTransform;
    [SerializeField] Transform wandProjectileSpawnPoint;
    [SerializeField] SpriteRenderer wandTipSpriteRenderer;
    [SerializeField] List<ABC_Magic> magicList;
    [SerializeField] Image crosshair;
    
    [SerializeField] ABC_Magic _currentMagic;
    MagicType _currentMagicType;

    float _currentCastCooldown;
    float _timeSinceLastCast = 999f;

    void OnEnable()
    {
        InputListener.OnInteractKeyDown += CycleWandMagicType;
        InputListener.OnLeftMouseButtonDown += CastMagic;
    }
    void OnDisable()
    {
        InputListener.OnInteractKeyDown -= CycleWandMagicType;
        InputListener.OnLeftMouseButtonDown -= CastMagic;  
    }

    void Start()
    {
        _currentMagicType = MagicType.Yellow;
        _currentMagic = GetMagicForType(_currentMagicType);
        _currentCastCooldown = _currentMagic.MagicData.CastCooldownInSeconds;
        GrantCastCooldown();
        StartCoroutine(ChangeWandTipColor(Color.yellow, Color.yellow));
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
                break;
            case MagicType.Red:
                _currentMagicType = MagicType.Blue;
                break;
            case MagicType.Blue:
                _currentMagicType = MagicType.Green;
                break;
            case MagicType.Green:
                _currentMagicType = MagicType.Yellow;
                break;
        }
        _currentMagic = GetMagicForType(_currentMagicType);
        _currentCastCooldown = _currentMagic.MagicData.CastCooldownInSeconds;
        GrantCastCooldown();
    }

    ABC_Magic GetMagicForType(MagicType magicType) => magicList.Find(magic => magic.MagicData.MagicType == magicType);

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
            crosshair.color = Color.Lerp(oldWantTipColor, newWandTipColor, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    public void CastMagic(GameObject target)
    {
        if (!CanCastMagic()) return;

        bool successfullyCastedMagic =_currentMagic.Cast(target);
        if (successfullyCastedMagic)
            ResetCastCooldown();
    }

    bool CanCastMagic() => _timeSinceLastCast >= _currentCastCooldown;
    public void ResetCastCooldown() => _timeSinceLastCast = 0f;
    public void GrantCastCooldown() => _timeSinceLastCast = _currentCastCooldown;
}

public enum MagicType
{
    Yellow,
    Red,
    Blue,
    Green
}