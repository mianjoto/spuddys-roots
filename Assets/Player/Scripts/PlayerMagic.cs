using UnityEngine;

public class PlayerMagic : MonoBehaviour
{
    void OnEnable() => InputListener.OnInteractKeyDown += CycleMagic.Cycle;
    void OnDisable() => InputListener.OnInteractKeyDown -= CycleMagic.Cycle;
}
