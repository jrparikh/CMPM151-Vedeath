﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement: MonoBehaviour {
	
	//Rigidbody2D enemyRigidBody;
	public Vector2 movement;
	public Transform enemyTransform;
	public Transform enemyContainerTransform;
	public Camera cam;

	private GameObject enemies;

	private float nextMove;
	public float moveTime;
	public float movSpeed;
	public float downSpeed;

	public float leftBoundary;
	public float rightBoundary;

	public bool turn;
	private bool leftMove;
	private bool rightMove;
	public Vector3 viewPos;

    public int metro = 300;

	public bool downTrue = false;

	// Use this for initialization
	void Start () {
		rightMove = true;
	}
	
	// Update is called once per frame
	void Update () {
		viewPos = cam.WorldToViewportPoint(enemyTransform.position);

		if (Time.time > nextMove) {
			nextMove = Time.time + moveTime;
			if (rightMove) {
				enemyContainerTransform.Translate (Vector3.right * movSpeed);
			}
		
			if (leftMove) {
				enemyContainerTransform.Translate (Vector3.right * -movSpeed);
			}
		}
			
		// Down on Left and Right Movement
		if (viewPos.x < leftBoundary && leftMove && !rightMove){
            metro -= 25;
            OSCHandler.Instance.SendMessageToClient("PD", "/PD/message/sequencer/metro", metro);
            rightMove = true;
			leftMove = false;
			enemyContainerTransform.Translate (Vector3.down * downSpeed);
			moveTime -= 0.05f;

		}

		// Down on Right and Left Movement
		if (viewPos.x > rightBoundary && rightMove && !leftMove) {
            metro -= 25;
            
                //*************
                OSCHandler.Instance.SendMessageToClient("PD", "/PD/message/sequencer/metro", metro);
                //*************
            
            rightMove = false;
			leftMove = true;
			enemyContainerTransform.Translate (Vector3.down * downSpeed);
			moveTime -= 0.05f;
		}
	}
}
