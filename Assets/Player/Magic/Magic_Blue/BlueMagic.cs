using UnityEngine;

public class BlueMagic : ABC_Magic
{
    // Identical to YellowMagic
    const string INTERACTABLE_PLANT_TAG = "InteractablePlant";
    
    public override void Awake() => base.Awake();

    public override bool Cast(GameObject target)
    {
        print("target: " + target);
        bool couldGrowPlant = false;
        if (target == null || !target.CompareTag(INTERACTABLE_PLANT_TAG)) return false;

        GrowPlant growPlant = target.TryGetComponent<GrowPlant>(out growPlant) ? growPlant : null;
        
        if (growPlant.MagicTypeRequiredToGrow == MagicType.Blue)
            couldGrowPlant = growPlant.TryToGrow();
        
        return couldGrowPlant;
    }

    public override void CastAffectTarget(GameObject target) => throw new System.NotImplementedException();
}
