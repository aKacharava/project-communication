using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //test
    public float moveSpeed = 8f;

    public Rigidbody rigBody;

    Vector3 movement;

    // Update is called once per frame
    void Update()
    {
        /// Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        /// Movement 
        rigBody.MovePosition(rigBody.position + movement.normalized * moveSpeed * Time.deltaTime);
    }
}
