using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    //public float xMin, xMax, zMin, zMax;

    void Start()
    {
        //************* Instantiate the OSC Handler...
        OSCHandler.Instance.Init();
        OSCHandler.Instance.SendMessageToClient("PD", "/unity/trigger", "ready");
        OSCHandler.Instance.SendMessageToClient("PD", "/PD/message/oscprep", "bang");
        OSCHandler.Instance.SendMessageToClient("PD", "/PD/message/volume/dimMusic", "bang");
        OSCHandler.Instance.SendMessageToClient("PD", "/PD/message/sequencer/pulse1", 1);
        OSCHandler.Instance.SendMessageToClient("PD", "/PD/message/sequencer/pulse2", 1);
        OSCHandler.Instance.SendMessageToClient("PD", "/PD/message/sequencer/waveform3", 1);
        OSCHandler.Instance.SendMessageToClient("PD", "/PD/message/sequencer/noise4", 1);
        OSCHandler.Instance.SendMessageToClient("PD", "/PD/message/sequencer/sequencer", 1);
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

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * speed;
        /*rb.velocity = new Vector2
        (
            Mathf.Clamp(rb.velocity.x, xMin, xMax),
            //0.0f,
            Mathf.Clamp(rb.velocity.y, zMin, zMax)
        );*/

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shootLaserSound();
        }

    }

    void shootLaserSound()
    {
        //*************
        OSCHandler.Instance.SendMessageToClient("PD", "/PD/message/soundEffects/bigLaser", "bang");
        //*************
    }
}
