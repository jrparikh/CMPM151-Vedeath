using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect_Down: MonoBehaviour {

	//Rigidbody2D enemyRigidBody;
	private Transform enemyTransform;
	public Camera cam;

	//private bool leftMove;
	//private bool rightMove;
	public Vector3 viewPos;

	public bool changeDirection;

	public bool downTrue = false;

	// Use this for initialization
	void Start () {
		//rightMove = true;
		this.changeDirection = false;
		this.enemyTransform = this.gameObject.transform;
	}

	// Update is called once per frame
	void Update () {
		this.changeDirection = false;
		this.viewPos = cam.WorldToViewportPoint(this.enemyTransform.position);

		// Down on Left and Right Movement
		if (this.viewPos.x < 0.1f)/*&& leftMove && !rightMove)*/{
			//rightMove = true;
			//leftMove = false;
			downTrue = true;
			this.changeDirection = true;
			//Debug.Log ("Change Direction: " + changeDirection);
		}

		// Down on Right and Left Movement
		if (this.viewPos.x > 0.9f /*&& rightMove && !leftMove*/) {
			//rightMove = false;
			//leftMove = true;
			downTrue = true; 
			this.changeDirection = true;
		}
		downTrue = false;
	}
}
