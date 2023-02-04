using UnityEngine;

public abstract class ABC_Magic : IMagic
{
    public SO_MagicData MagicData;
    public abstract void Cast();
    public abstract void CastAffectTarget();
}
