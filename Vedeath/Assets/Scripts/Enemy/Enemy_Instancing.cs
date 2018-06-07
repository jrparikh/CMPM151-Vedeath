using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Instancing : MonoBehaviour {
	public Transform enemyContainer;
	public GameObject enemy;
	public static Object ins;

	public float x;
	public float y;

	// Use this for initialization
	void Start () {
		//enemyTransform = gameObject.GetComponent<Transform> ();
		for (int i = 0; i < 5; i++) {
			Instantiate(enemy, new Vector3(i * 0.75f, y, 0), Quaternion.identity, enemyContainer);
			Instantiate(enemy, new Vector3(i * -0.75f, y, 0), Quaternion.identity, enemyContainer);

			//Next Row
			Instantiate (enemy, new Vector3 (i * 0.75f, y - 1, 0), Quaternion.identity, enemyContainer);
			Instantiate (enemy, new Vector3 (i * -0.75f, y - 1, 0), Quaternion.identity, enemyContainer);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
