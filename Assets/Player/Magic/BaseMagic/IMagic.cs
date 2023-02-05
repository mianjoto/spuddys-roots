using UnityEngine;

public interface IMagic
{
    bool Cast(GameObject target);
    void CastAffectTarget(GameObject target);
}
