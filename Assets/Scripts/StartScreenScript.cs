using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreenScript : MonoBehaviour {
    public Text CurrentHighScore;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Startgame()
    {
        SceneManager.LoadScene(1);
    }
}
