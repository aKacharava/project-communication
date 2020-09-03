using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraLock : MonoBehaviour
{
    public Transform target;
    public float distanceY;
    public float distanceZ;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(target.position.x, target.position.y + distanceY, target.position.z + distanceZ);
        this.transform.Rotate(0, 0, 0);
    }
}
