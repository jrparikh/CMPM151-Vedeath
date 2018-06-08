using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Kill : MonoBehaviour {

	//public GameObject bullet;
    private static int count;

	// Update is called once per frame
	void Update () {

    }

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "laser") {
            //*************
            OSCHandler.Instance.SendMessageToClient("PD", "/PD/message/soundEffects/bigExplosion", "bang");
            //*************
            count++;
            if (count >= 40)
            {
                //*************
                OSCHandler.Instance.SendMessageToClient("PD", "/PD/message/soundEffects/getItem", "bang");
                //*************
            }
            Destroy(this.gameObject);
			other.GetComponent<Renderer>().enabled = !other.GetComponent<Renderer> ().enabled;
			Destroy (other);
            
			//Debug.Log ("It's Colliding!");
		}
	}
}
