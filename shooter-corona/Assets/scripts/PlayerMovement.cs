using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

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
        rigBody.MovePosition(rigBody.position + movement * moveSpeed * Time.deltaTime);
    }
}
