﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    void Start()
    {
        //************* Instantiate the OSC Handler...
        OSCHandler.Instance.Init();
        OSCHandler.Instance.SendMessageToClient("PD", "/unity/trigger", "ready");
        //*************
    }

    void FixedUpdate()
    {
        //************* Routine for receiving the OSC...
        OSCHandler.Instance.UpdateLogs();
        Dictionary<string, ServerLog> servers = new Dictionary<string, ServerLog>();
        servers = OSCHandler.Instance.Servers;
        //*************


        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb = GetComponent<Rigidbody2D>();

        Vector3 movement = new Vector3(moveHorizontal, moveVertical);
        rb.velocity = movement * speed;

        /*rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );*/

        //rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            shootLaserSound();
        }
        
    }
    void shootLaserSound()
    {
        //************* Send the message to the client...
        OSCHandler.Instance.SendMessageToClient("PD", "/PD/message/soundEffects/bigLaser", 1);
        //*************
    }

}