using UnityEngine;

[CreateAssetMenu(fileName = "New Magic Data", menuName = "Magic Data", order = 51)]
public class SO_MagicData : ScriptableObject
{
    [Header("Magic Type")]
    public MagicType MagicType;

    #region Magic Projectile Settings
    [Header("Magic Projectile")] [Tooltip("Settings for the magic projectile, a projectile may not exist for all magic types")]
    public GameObject MagicProjectilePrefab;
    public float MagicProjectileMoveSpeedInUnitsPerSecond;
    #endregion

    #region Casting Settings
    [Header("Casting")]
    [HideInInspector] public float CastCooldownInSeconds;
    [HideInInspector] public float CastRangeInUnitsPerSecond;
    [HideInInspector] public float CastDurationInSeconds;
    [HideInInspector] public float CastAffectTargetDurationInSeconds;
    #endregion
}
