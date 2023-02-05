using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float backgroundSize;
    public float parallaxSpeed;

    [SerializeField] Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;

    
    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        textureUnitSizeX = backgroundSize / GetComponent<Renderer>().bounds.size.x;
    }

    void Update()
    {
        float deltaX = cameraTransform.position.x - lastCameraPosition.x;
        transform.position += Vector3.right * (deltaX * parallaxSpeed);
        lastCameraPosition = cameraTransform.position;

        if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
        {
            float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
        }
    }
}
