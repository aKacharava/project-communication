using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    float delay = 3f;

    void Start()
    {
        Destroy(this.gameObject, delay);
    }
}
