using System;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public static Action OnFireballHitObject;
    float _initialRotation;
    float _moveSpeed;
    RedMagic _redMagic;
    
    const string INTERACTABLE_PLANT = "InteractablePlant";

    public void Initialize(float initialRotation, float moveSpeed, RedMagic redMagic)
    {
        _initialRotation = initialRotation;
        _moveSpeed = moveSpeed;
        _redMagic = redMagic;
    }

    void Start() => transform.eulerAngles = new Vector3(0, 0, _initialRotation);
    void Update() => MoveForward();
    void MoveForward() => transform.Translate(Vector2.up * _moveSpeed * Time.deltaTime);

    void OnCollisionEnter2D(Collision2D other)
    {
        OnFireballHitObject?.Invoke();
        Debug.Log("Fireball hit object");
        if (other.gameObject.CompareTag(INTERACTABLE_PLANT))
        {
            // TODO: Add decomposition coroutine
            _redMagic.CastAffectTarget(other.gameObject);
        }
        Destroy(this.gameObject);
    }
}
