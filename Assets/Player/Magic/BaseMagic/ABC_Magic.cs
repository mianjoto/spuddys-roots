using UnityEngine;

public abstract class ABC_Magic : MonoBehaviour, IMagic
{
    public SO_MagicData MagicData;
    public GameObject MagicProjectilePrefab;
    [HideInInspector] public float CastCooldown;
    [HideInInspector] public float CastRange;
    [HideInInspector] public float CastDuration;
    [HideInInspector] public float CastAffectTargetDuration;

    public virtual void Awake()
    {
        MagicProjectilePrefab = MagicData.MagicProjectilePrefab;
        CastCooldown = MagicData.CastCooldownInSeconds;
        CastRange = MagicData.CastRangeInUnitsPerSecond;
        CastDuration = MagicData.CastDurationInSeconds;
        CastAffectTargetDuration = MagicData.CastAffectTargetDurationInSeconds;
    }

    public abstract void Cast();
    public abstract void CastAffectTarget(GameObject target);
}
