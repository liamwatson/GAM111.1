using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    // Game Lives Variables
    public int GateLives = 20;
    //turret power variable
    public float turretPower = 500;
    public Slider powerbar;
    //pause variable
    bool ispaused = false;

    // Ui Variables
    public Text Score_UITEXT;
    public Text Time_UITEXT;
    public Text Portallives_UITEXT;

    //Time variables
    public float time = 300;

    // score variables
    public int score = 0;
    int currenthighscore = 1;

    //sound variables
    public AudioSource cannonsound;
    public AudioClip oww1;
    public AudioClip oww2;
    public AudioClip oww3;
    public AudioClip oww4;
    public AudioClip oww5;
    private AudioClip Emptysound;

    //cannon variables and tracer
    public GameObject tracerball;
    public GameObject Cannonball;
    public GameObject Barrelend;
    public float firecountdown = 1;
    private float canfire = 0f;
    
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

    void Awake()
    {
        //instance of this for singleton
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {
        //setup the current spawning interval
        timercurrent = SpawnInterval;
        //load in the current high score for comparison
        currenthighscore = PlayerPrefs.GetInt("highscore");
    }

    // this function spawns the enemy
    private void Spawner()
    {
        //set a random number and spawns the enemy at the random spawn point
        Spawnpicker = Random.Range(0, SpawnPoints.Length);
        currentspawnpoint = SpawnPoints[Spawnpicker];
        Instantiate(Enemy, currentspawnpoint.transform.position, currentspawnpoint.transform.rotation);
    }

    //function used to count down from 300 seconds, then win code
    void Gametime()
    {
        time -= Time.deltaTime;
        string timestring = "Time: " + time.ToString("F0");
        Time_UITEXT.text = timestring;

        if (time <= 0)
        {
            //when player wins the game 
            PlayerPrefs.SetInt("endingscore", score);
            PlayerPrefs.SetInt("won", 1);
            SceneManager.LoadScene(2);
        }
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
  
    //function that handles the damage for the gate named portal damage
    public void GateDamage()
    {
        GateLives -= 1;
        string Portallivesupdate = "Gate Lives: " + GateLives;
        Portallives_UITEXT.text = Portallivesupdate;
        //run this if gate lifes get to 0
        if (GateLives <= 0)
        {
            //player pref won 0 means its not true and the player actually lost.
            PlayerPrefs.SetInt("won", 0);
            PlayerPrefs.SetInt("endingscore", score);
            SceneManager.LoadScene(2);
        }
    }
	
	// Update is called once per frame
	void Update () {
        firecannon();
        SpawnerTimer();
        Gametime();
        spawnincreser();
        TARGETRECT();
    }

    //as the time diminishes spawn more enemys making the game harder as time goes on
    private void spawnincreser()
    {
        if (time > 250)
            SpawnInterval = 3;
        if (time > 200 && time <= 250)
            SpawnInterval = 2.5f;
        if (time > 150 && time <= 200)
            SpawnInterval = 2.0f;
        if (time > 100 && time <= 150)
            SpawnInterval = 1.5f;
        if (time > 50 && time <= 100)
            SpawnInterval = 1f;
        if (time > 0 && time <= 50)
            SpawnInterval = 0.5f;
    }

    //sound function
    public void playsound(int soundtoplay)
    {
        //plays a sound depending on the argument given.
        if (soundtoplay == 1)
            Emptysound = oww1;
        if (soundtoplay == 2)
            Emptysound = oww2;
        if (soundtoplay == 3)
            Emptysound = oww3;
        if (soundtoplay == 4)
            Emptysound = oww4;
        if (soundtoplay == 5)
            Emptysound = oww5;
        AudioSource.PlayClipAtPoint(Emptysound, transform.position, 0.5f);
    }

    //score function
    public void scorefunction(int scoreadder, int scoremultiplier)
    {
        // this will reward score based on enemies killed
        score += scoreadder * scoremultiplier;
        string scoreupdate = "Score: " + score;
        Score_UITEXT.text = scoreupdate;
    }

    //function to pause the game
    public void pausegame()
    {
        if (ispaused == false)
        {
            //time scale of 0 means everything stops
            Time.timeScale = 0.0f;
            ispaused = true;
        }
        else if (ispaused == true)
        {
            Time.timeScale = 1.0f;
            ispaused = false;
        }
    }

    //function to fire the cannon
    public void firecannon()
    {
        //this sets the power of the turret by using the slider
        turretPower = powerbar.value;
        //checks to see if the cooldown is met and the space is pressed
        if (Input.GetKey("space")&& Time.time > canfire)
        { 
        GameObject firedball;
        //instantiates the cannonball and adds force depending on the slider
        firedball = Instantiate(Cannonball, Barrelend.transform.position, Barrelend.transform.rotation) as GameObject;
        firedball.GetComponent<Rigidbody>().AddForce(Barrelend.transform.forward * turretPower);
        //cannon sound
        cannonsound.Play();
        //resets the cooldown
        canfire = Time.time + firecountdown;
        }
    }
    public void TARGETRECT()
    {
        //this sets the power of the turret by using the slider
        float Power = powerbar.value * 7;
        //checks to see if the cooldown is met and the space is pressed
            GameObject tracer;
            //instantiates the cannonball and adds force depending on the slider
            tracer = Instantiate(tracerball, Barrelend.transform.position, Barrelend.transform.rotation) as GameObject;
            tracer.GetComponent<Rigidbody>().AddForce(Barrelend.transform.forward * Power);
    }
}


