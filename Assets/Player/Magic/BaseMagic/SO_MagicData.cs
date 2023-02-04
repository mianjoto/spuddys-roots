using UnityEngine;

[CreateAssetMenu(fileName = "New Magic Data", menuName = "Magic Data", order = 51)]
public class SO_MagicData : ScriptableObject
{
    [Header("Magic Type")]
    public MagicType MagicType;

    #region Magic Projectile Settings
    [Header("Magic Projectile")] [Tooltip("Settings for the magic projectile, a projectile may not exist for all magic types")]
    public float MagicProjectileMoveSpeedInUnitsPerSecond;
    #endregion

    #region Casting Settings
    [Header("Casting")]
    public float CastCooldownInSeconds;
    public float CastRangeInUnitsPerSecond;
    public float CastDurationInSeconds;
    public float CastAffectTargetDurationInSeconds;
    #endregion
}
