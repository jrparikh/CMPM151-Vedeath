using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement: MonoBehaviour {
	
	//Rigidbody2D enemyRigidBody;
	public Vector2 movement;
	Transform enemyTransform;
	public Camera cam;

	private float nextMove;
	public float moveTime;
	public float movSpeed;
	public float downSpeed;

	private bool leftMove;
	private bool rightMove;

	// Use this for initialization
	void Start () {
		//enemyRigidBody = gameObject.GetComponent<Rigidbody2D> ();
		enemyTransform = gameObject.GetComponent<Transform> ();
		rightMove = true;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 viewPos = cam.WorldToViewportPoint(enemyTransform.position);
		Debug.Log ("Position: " + viewPos);

		if (Time.time > nextMove) {
			nextMove = Time.time + moveTime;
			if (rightMove) {
				enemyTransform.Translate (Vector3.right * movSpeed);
			}
		
			if (leftMove) {
				enemyTransform.Translate (Vector3.right * -movSpeed);
			}

			Debug.Log ("Left: " + leftMove + ", Right: " + rightMove);
		}

		// Down on Left and Right Movement
		if (viewPos.x < 0.1f && leftMove && !rightMove){
			rightMove = true;
			leftMove = false;
			enemyTransform.Translate (Vector3.down * downSpeed);
			Debug.Log ("Down Called");
		}
		// Down on Right and Left Movement
		if (viewPos.x > 0.9f && rightMove && !leftMove) {
			rightMove = false;
			leftMove = true;
			enemyTransform.Translate (Vector3.down * downSpeed);
			Debug.Log ("Down Called");
		}
	}
}
