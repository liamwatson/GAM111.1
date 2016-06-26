using UnityEngine;
using System.Collections;

public class tracer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(this.gameObject, 0.3f);
	}
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(Physics.gravity * 63f);
    }
    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
