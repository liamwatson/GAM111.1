using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartManager : MonoBehaviour {

    //Variables for start screen
    private int currenthighscore;
    public Text highscore;

	//initialize the highscore and display it
	void Start () {
        currenthighscore = PlayerPrefs.GetInt("highscore");
        highscore.text = "High Score: " +currenthighscore.ToString();
    }

    //button the start the game
    public void Startbutton()
    {
        SceneManager.LoadScene(1);
    }
}
