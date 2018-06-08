using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Kill : MonoBehaviour {

    private bool res = false;
    //private float timer = 0;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

	void OnTriggerEnter2D(Collider2D other){
		//if (other.tag == "enemy_laser") {
			Debug.Log("Triggered Player Kill");
        //*************
        OSCHandler.Instance.SendMessageToClient("PD", "/PD/message/soundEffects/bigExplosion", "bang");
        //*************
        //res = true;
        //timer = Time.time + 2f;
        //StartCoroutine(Restart());
        Destroy(this.gameObject);
			other.GetComponent<Renderer>().enabled = !other.GetComponent<Renderer> ().enabled;
			Destroy (other);

        //}
    }
   /* IEnumerator Restart()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }*/
}
