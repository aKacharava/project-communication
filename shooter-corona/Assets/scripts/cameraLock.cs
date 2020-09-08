using UnityEngine;

public class cameraLock : MonoBehaviour
{
    public Transform target;
    public float distanceY;
    public float distanceZ;
    public float smooth;

    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = new Vector3(target.position.x, target.position.y + distanceY, target.position.z + distanceZ);
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);
    }
}
