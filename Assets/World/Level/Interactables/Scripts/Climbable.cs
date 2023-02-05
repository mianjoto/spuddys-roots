using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Climbable : MonoBehaviour
{
    BoxCollider2D _col;

    const string PLAYER_TAG = "Player";

    void Awake()
    {
        if (_col == null)
            _col = GetComponent<BoxCollider2D>();
        _col.isTrigger = true;        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != PLAYER_TAG) return;
        PlayerMovement.CanClimb = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag != PLAYER_TAG) return;
        PlayerMovement.CanClimb = false;
    }
}
