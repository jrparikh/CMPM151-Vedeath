using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    // Use this for initialization
	public Camera cam;
	public Vector3 viewPos;
    public float VelX = 0f;
    public float VelY = 5f;
    Rigidbody2D rb;


    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
		cam = (Camera)FindObjectOfType (typeof(Camera));
    }


    void Update()
    {
		viewPos = cam.WorldToViewportPoint(this.gameObject.transform.position);

        this.rb.velocity = new Vector2(VelX, VelY);

		if (this.viewPos.y < 0 || this.viewPos.y > 1){
			Destroy (this.gameObject);
		}
    }
}
