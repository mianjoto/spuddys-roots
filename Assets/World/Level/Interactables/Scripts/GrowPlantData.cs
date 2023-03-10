using UnityEngine;

[CreateAssetMenu(fileName = "GrowPlantData", menuName = "ScriptableObjects/GrowPlantData", order = 1)]
public class GrowPlantData : ScriptableObject
{
    [Header("Magic Access")]
    public MagicType MagicTypeRequiredToGrow;
    
    [Header("Growth stats")]
    public float GrowthDuration = 3f;
    public float BeforeGrowthYScale = 1f;
    public float AfterGrowthYScale = 18f;

    [Header("Shrink stats")]
    public bool DoShrinkAfterGrowth = true;
    public float StayGrownDuration = 8f;
    public float ShrinkDuration = 5f;
}
