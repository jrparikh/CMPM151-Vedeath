using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
    public GameObject Projectile;

    public float fireSpeed;
    public float fireRate;
    //public Transform Player;
    //public float speed;

    void Update()
    {

        //transform.rotation = Player.transform.rotation;

        if (Input.GetKey(KeyCode.Mouse0) && Time.time > fireRate)
        {
            fireRate = Time.time + fireSpeed;
            Instantiate(this.Projectile, this.transform.position, this.transform.rotation);

        }
    }
}