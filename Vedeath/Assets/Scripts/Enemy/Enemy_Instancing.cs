using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Instancing : MonoBehaviour {
	public Transform enemyTransform;

	// Use this for initialization
	void Start () {
		//enemyTransform = gameObject.GetComponent<Transform> ();
		for (int i = 0; i < 10; i++) {
			Instantiate(enemyTransform, new Vector3(i * 0.75f - 4, 3, 0), Quaternion.identity);
			Instantiate (enemyTransform, new Vector3 (i * 0.75f - 4, 2, 0), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
