using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    //declare variables
    public GameObject turretBarrel;

    //turret rotation variables
    public float turretrotationspeed = 30;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        rotateTurret();
	}


    //rotate turret function
    private void rotateTurret()
    {

        //rotate the base left
        if (Input.GetKey("a") && transform.rotation.x > -0.4)
        {
            transform.Rotate(Vector3.left * Time.deltaTime * turretrotationspeed);
        }
        //rotate the base right
        if (Input.GetKey("d") && transform.rotation.x < 0.4)
        {
            transform.Rotate(Vector3.right * Time.deltaTime * turretrotationspeed);
        }
        //rotate the barrel up
        if (Input.GetKey("w"))
        {
            turretBarrel.transform.Rotate(Vector3.up * Time.deltaTime * turretrotationspeed);
        }
        //rotate the barrel up
        if (Input.GetKey("s"))
        {
            turretBarrel.transform.Rotate(Vector3.down * Time.deltaTime * turretrotationspeed);
        }
      }
    
}
