using UnityEngine;

public class GreenMagic : ABC_Magic
{
    [SerializeField] GameObject lilypad;
    Rigidbody2D _lilypadRigidbody;
    Transform _lilypadTransform;

    public override void Awake()
    {
        base.Awake();
        _lilypadTransform = lilypad.transform;
        _lilypadRigidbody = lilypad.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        lilypad.SetActive(false);
    }

    public override void Cast(GameObject target)
    {
        // Do not spawn the lilypad if player is clicking on an object
        if (target != null) return; 

        if (!lilypad.activeSelf) lilypad.SetActive(true);

        // Move the lilypad to the cursor's position
        var mousePositionInWorld = InputListener.MousePositionInWorld;
        _lilypadTransform.position = new Vector3(mousePositionInWorld.x, mousePositionInWorld.y, _lilypadTransform.position.z);
        _lilypadTransform.rotation = Quaternion.identity;
        _lilypadRigidbody.velocity = Vector2.zero;
    }

    public override void CastAffectTarget(GameObject target) => throw new System.NotImplementedException();
}
