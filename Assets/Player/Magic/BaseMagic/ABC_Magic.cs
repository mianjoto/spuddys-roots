using UnityEngine;

public abstract class ABC_Magic : MonoBehaviour, IMagic
{
    public SO_MagicData MagicData;
    [HideInInspector] public float CastCooldown;
    [HideInInspector] public float CastRange;
    [HideInInspector] public float CastDuration;
    [HideInInspector] public float CastAffectTargetDuration;

    public virtual void Awake()
    {
        CastCooldown = MagicData.CastCooldownInSeconds;
        CastRange = MagicData.CastRangeInUnitsPerSecond;
        CastDuration = MagicData.CastDurationInSeconds;
        CastAffectTargetDuration = MagicData.CastAffectTargetDurationInSeconds;
    }

    public abstract void Cast(GameObject target);
    public abstract void CastAffectTarget(GameObject target);
}
