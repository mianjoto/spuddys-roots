using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    const string RESPAWN_POINT_TAG = "Respawn";
    void Start() => gameObject.tag = RESPAWN_POINT_TAG;
    public void Activate()
    {
        // TODO: Animation and sounds
    }
}
