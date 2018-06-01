using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Instancing : MonoBehaviour {
	public Transform enemyTransform;

	// Use this for initialization
	void Start () {
		enemyTransform = gameObject.GetComponent<Transform> ();
		for (int i = 0; i < 10; i++) {
			Instantiate(enemyTransform, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
