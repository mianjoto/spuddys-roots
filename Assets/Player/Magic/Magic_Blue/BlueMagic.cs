using UnityEngine;

public class BlueMagic : ABC_Magic
{
    // Identical to YellowMagic
    const string INTERACTABLE_PLANT_TAG = "InteractablePlant";
    
    public override void Awake() => base.Awake();

    public override void Cast(GameObject target)
    {
        if (target == null || !target.CompareTag(INTERACTABLE_PLANT_TAG)) return;

        GrowPlant growPlant = target.TryGetComponent<GrowPlant>(out growPlant) ? growPlant : null;
        
        if (growPlant.MagicTypeRequiredToGrow == MagicType.Blue)
            growPlant.TryToGrow();
    }

    public override void CastAffectTarget(GameObject target) => throw new System.NotImplementedException();
}
