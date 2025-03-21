using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public static bool gameOver;
    public static bool won;
    public static int score;
    public GameObject textBG;
    bool gameStarted = false;
    private int activePlayers = 2; // Track the number of players remaining

    public TMP_Text textbox;
    public int scoreToWin;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gameOver = false;
        won = false;
        score = 0;
    }

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

        if (gameOver)
        {
            textbox.text = "WE HAVE A KING!\nPress R to Try Again.";

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void PlayerEliminated()
    {
        activePlayers--;

        if (activePlayers == 1)
        {
            gameOver = true;
        }
    }
}
