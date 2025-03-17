using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    // Public static variables
    // Can be accessed from any script but cannot be seen in the inspector
    public static bool gameOver;
    public static bool won;
    public static int score;
    public GameObject textBG;
    bool gameStarted = false;

    // Reference to our textbox
    // Must be set in the inspector
    public TMP_Text textbox;
    public int scoreToWin;

    // Start is called before the first frame update
    void Start()
    {
        // init values
	    gameOver = false;
	    won = false;
	    score = 0;

        textbox.text = "Player 1: WASD - Player 2: IDJK (Move)" +
            "\nPlayer 1: Space - Player 2: Slash (Jump)" +
            "\nPlayer 1: Left Shift - Player 2: Right Shift (Bomb)" +
            "\n\nCollect the crown to gain the ability to bomb your opponents!" +
            "\nYou can only throw a limited number of bombs before losing the" +
            "\ncrown, causing it to respawn so that it may be picked up again." +
            "\nGet hit with enough bombs and you'll be eliminated." +
            "\nLast player standing wins." +
            "\n\nPress Enter when you are ready to play!";
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                textbox.text = "FIGHT!";
                textBG.GetComponent<Renderer>().enabled = false;
                gameStarted = true;
            }
        }

        if (gameOver) {
		    textbox.text = "WE HAVE A KING!\nPress R to Try Again.";

	        if (Input.GetKeyDown(KeyCode.R))
		    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	    }
    }
}
