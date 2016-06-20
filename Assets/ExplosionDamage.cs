using UnityEngine;
using System.Collections;

public class ExplosionDamage : MonoBehaviour {
    //variables for the exposion damage
    public float lifetime = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0) {
            Destroy(this.gameObject);
        }
	}
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Debug.Log("killed an enemy");
        }
    }
}
