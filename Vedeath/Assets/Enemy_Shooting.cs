using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooting : MonoBehaviour {

	//public Ray2D detectZone;
	//public RaycastHit2D detectResult;
	public LayerMask myLayerMask;

	public Vector2 rayOrigin;
	public GameObject enemyProjectile;
	public GameObject player;

	public float laserLife;
	public float fireRate;
	public float fireSpeed;
	public bool fire;

	// Use this for initialization
	void Start () {
		this.fire = false;
		this.fireRate = Random.Range (1f, 2f);
		this.fireSpeed = Random.Range (10f, 20f);
		//this.rayOrigin = gameObject.transform.position;

		//Physics2D.queriesStartInColliders = false;
	}

	// Update is called once per frame
	void Update () {
		RaycastHit2D detectResult = Physics2D.Raycast (this.transform.position, -transform.up, 5, myLayerMask);
		if (detectResult.collider != null) {
			Debug.DrawLine (this.transform.position, detectResult.point, Color.red);
		} else {
			this.fire = true;
			Debug.DrawLine (this.transform.position, this.transform.position + -transform.up * 5, Color.green);

		}

		//RaycastHit2D detectResult;
		//Ray2D detectZone;
		/*Debug.DrawRay(this.transform.position, this.transform.TransformDirection(Vector2.down), Color.green);
		/*if (Physics2D.Raycast (this.transform.position, this.transform.TransformDirection(Vector2.down), 10f)){

		}*/

		if (this.fire && Time.time > this.fireRate)
		{
			this.fireRate = Time.time + this.fireSpeed;
			Instantiate(this.enemyProjectile, this.transform.position, this.transform.rotation);

		}
	}
}
