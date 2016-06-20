using UnityEngine;
using System.Collections;

public class ExplisionDetection : MonoBehaviour {
    public GameObject Explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    //detect if the cannon ball has hit the floor
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            //create the explosion effect on the ground at the location of the collision
            Instantiate(Explosion, other.transform.position, transform.rotation);

            //destroy the cannon ball
            Destroy(other.gameObject);
        }
    }
}
