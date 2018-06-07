using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Kill : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		//if (other.tag == "enemy_laser") {
			Debug.Log("Triggered Player Kill");
			Destroy (this.gameObject);
			other.GetComponent<Renderer>().enabled = !other.GetComponent<Renderer> ().enabled;
			Destroy (other);
		//}
	}
}
