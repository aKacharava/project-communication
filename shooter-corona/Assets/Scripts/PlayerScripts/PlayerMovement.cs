using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8f;
    public Rigidbody rigBody;

    Vector3 movement;

    void Update()
    {
        /// Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        
        if(Input.GetKey(KeyCode.W) || 
           Input.GetKey(KeyCode.A) || 
           Input.GetKey(KeyCode.S) || 
           Input.GetKey(KeyCode.D))
        {
            SoundManager.PlaySound("walking sound", false, false);
        }

        else
        {
            SoundManager.StopSound("walking sound", false);
        }
    }

    void FixedUpdate()
    {
        /// Movement 
        rigBody.MovePosition(rigBody.position + movement.normalized * moveSpeed * Time.deltaTime);

    }
}
