using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    //variables SPAWNING
    private int Endpointpicker;
    private GameObject currentendpoint;
    //variables MOVEMENT
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 2.0f;
    private float adjRotSpeed;
    private Quaternion TargetRotation;
    //variables HEALTH
    public float Health = 100;

    // Use this for initialization
    void Start () {
        //gets a random end point from 0 - 3
        Endpointpicker = Random.Range (1, 5);
        currentendpoint = GameObject.Find("End Point " + Endpointpicker); 
    }
	
	// Update is called once per frame
	void Update () {
        Movement();
    }

    //movment function
    private void Movement()
    {
        if (currentendpoint != null)
        {
            //rotate towards the currentendpoint
            TargetRotation = Quaternion.LookRotation(currentendpoint.transform.position - transform.position);
            adjRotSpeed = Mathf.Min(rotationSpeed * Time.deltaTime, 1);
            transform.rotation = Quaternion.Lerp(transform.rotation, TargetRotation, adjRotSpeed);
        }

        //move forward
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    //Base Enemy take damage functionality
    public void TakeDamage(float damage)
    {
        Health -= damage;

        if (Health <= 0)
            Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Portal"))
        {
            Destroy(this.gameObject);
            GameController.Instance.PortalDamage();
        }
    }
}
