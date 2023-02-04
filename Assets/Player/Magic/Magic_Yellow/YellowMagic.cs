using UnityEngine;

public class YellowMagic : ABC_Magic
{
    const string INTERACTABLE_PLANT_TAG = "InteractablePlant";
    
    public override void Awake() => base.Awake();

    public override void Cast(GameObject target)
    {
        if (!target.CompareTag(INTERACTABLE_PLANT_TAG)) return;

        GrowPlant growPlant = target.TryGetComponent<GrowPlant>(out growPlant) ? growPlant : null;
        print("growPlant: " + growPlant);
        growPlant.TryToGrow();
    }

    public override void CastAffectTarget(GameObject target)
    {
        // Destroy(target); // Ignore target for Yellow Magic
    }
}
