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

    //variables Score Per Kill
    public int SPK = 50;

    //varialbes for knockback amount
    public float knockbackamount = 0.5f;

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
        //checks to make sure there is an endpoint
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

    //function to cause the knockback when enemys are hit
    public void Knockback()
    {
        transform.position -= transform.forward * knockbackamount;
    }

    //Base Enemy take damage functionality
    public void TakeDamage(float damage)
    {
        Health -= damage;
        
        //randomiser to make it play a sound
        int willsoundplay = Random.Range(1, 4);
        if (willsoundplay == 1)
        {
            int soundrnd = Random.Range(1, 6);
            GameController.Instance.playsound(soundrnd);
        }
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            //spk is score per kill
            GameController.Instance.scorefunction(SPK, 1);
        }
    }

    //check if the enemy clone has contacted the gate/portal
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Portal"))
        {
            Destroy(this.gameObject);
            //if it has then run gate damage, this does 1 damage to the gate/portal
            GameController.Instance.GateDamage();
        }
    }
}
