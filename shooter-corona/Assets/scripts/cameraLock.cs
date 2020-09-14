using UnityEngine;

public class CameraLock : MonoBehaviour
{
    public Transform target;
    public float distanceY;
    public float distanceZ;
    public float smooth;

    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        Vector3 pos = new Vector3(target.position.x, target.position.y + distanceY, target.position.z + distanceZ);
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);
    }
}
