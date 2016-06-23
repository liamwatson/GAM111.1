using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreenScript : MonoBehaviour {

    //variables for end screen
    public Text endingscore;
    public Text endingresult;

    //variables for score and win/loss
    int score = 0;
    int highscore;
    int haswon;

    // Use this for initialization
    void Start () {

        //initialize the player prefs
        haswon = PlayerPrefs.GetInt("won");
        highscore = PlayerPrefs.GetInt("highscore");
        score = PlayerPrefs.GetInt("endingscore");

        //check to see if the player won(1) or lost(0)
        if (haswon == 0)
        {
            endingresult.text = "The Horde Broke Through and killed everyone, your score does not count";
            endingscore.text = score.ToString();
        }

        if (haswon == 1)
        {
            //check to see if there was a new highscore for text purposes.
            if (score > highscore)
            {
                endingresult.text = "You Defended the horde and set a new highscore";
                endingscore.text = "Score: "+score.ToString();
            }

            if (score <= highscore)
            {
                endingresult.text = "You Defended But didnt get a new high score";
                endingscore.text = "Score: "+score.ToString();
            }
        } 
    }
	
    //button for returning to the main menu
    public void Mainmenu()
    {
        SceneManager.LoadScene(0);
    }
}
