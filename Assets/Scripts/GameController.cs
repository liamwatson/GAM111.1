using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    // Game Lives Variables
    public int PortalLives = 20;

    //cannon variables
    public GameObject Cannonball;
    public GameObject Barrelend;
    public float firecountdown = 1;
    public float canfire = 0;
    
    //spawn variables
    public GameObject Enemy;
    public GameObject[] SpawnPoints;
    private GameObject currentspawnpoint;
    private int Spawnpicker;

    //spawn timer variables
    public float SpawnInterval = 10;
    private float timercurrent;

    //make this a singleton
    public static GameController Instance;
    
    // this function spawns the enemy
    private void Spawner()
    {
        //set a random number 
        Spawnpicker = Random.Range(0, SpawnPoints.Length);
        currentspawnpoint = SpawnPoints[Spawnpicker];
        Instantiate(Enemy, currentspawnpoint.transform.position, currentspawnpoint.transform.rotation);
    }

    // this function counts down and then runs the spawner function
    void SpawnerTimer() {

        timercurrent -= Time.deltaTime;
        if (timercurrent <= 0)
        {
            Spawner();
            timercurrent = SpawnInterval;
        }
    }
    void Awake()
    {
        Instance = this;
    }
	// Use this for initialization
	void Start () {
        timercurrent = SpawnInterval;
    }

    public void PortalDamage()
    {
        PortalLives -= 1;
        Debug.Log("Lives Remaning" + PortalLives);
        if (PortalLives <= 0)
        {
            Debug.Log("Lost Game"); //COODEE NEEEDED HERERERER!!!!!!!!!!!!!!!!!!!!!!!!!
        }
    }
	
	// Update is called once per frame
	void Update () {
        firecannon();
        SpawnerTimer();
	}

    private void firecannon() {
        if (Input.GetKey("space")&& Time.time > canfire)
        {
            GameObject firedball;
            firedball = Instantiate(Cannonball, Barrelend.transform.position, Barrelend.transform.rotation)as GameObject;
            firedball.GetComponent<Rigidbody>().AddForce(Barrelend.transform.forward *700);
           
           canfire = Time.time + firecountdown;
        }
    }
}
