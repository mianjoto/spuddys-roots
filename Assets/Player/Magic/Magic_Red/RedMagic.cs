using UnityEngine;

public class RedMagic : ABC_Magic
{
    [SerializeField] Transform _magicProjectileSpawnPoint;
    Transform _transform;
    float _moveSpeed;

    public override void Awake()
    {
        base.Awake();
        _transform = transform;
    }

    void Start() => _moveSpeed = base.MagicData.MagicProjectileMoveSpeedInUnitsPerSecond;

    public override void Cast()
    {
        GameObject fireballInstance = Instantiate(MagicProjectilePrefab, _magicProjectileSpawnPoint.position, _transform.rotation);
        Fireball fireball = fireballInstance.GetComponent<Fireball>();
        fireball.Initialize(initialRotation: _transform.eulerAngles.z, moveSpeed: _moveSpeed, redMagic: this);
    }

    public override void CastAffectTarget(GameObject target)
    {
        Destroy(target);
    }
}
