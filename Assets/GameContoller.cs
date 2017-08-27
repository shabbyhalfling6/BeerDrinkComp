using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameContoller : MonoBehaviour {

    private float timer = 0.0f;
    public float timerIn = 40.0f;

    private float mainMenuTimer = 0.0f;
    public float mainMenuTimerIn = 5.0f;

    private float gameOverTimer = 0.0f;
    public float gameOverTimerIn = 5.0f;

    public Text countDownText;
    public Text mainMenuCountDownText;
    public Text startGameText;
    public Text winnerText;

    public GameObject gameOverMenu;
    public GameObject mainMenu;
    public GameObject drinkText;

    public PlayerController player1;
    public PlayerController player2;

    private bool isGameOver = false;
    private bool isMainMenu = true;

    private bool buttonPressed = false;

	// Use this for initialization
	void Start ()
    {
        timer = timerIn;
        mainMenuTimer = mainMenuTimerIn;
        gameOverTimer = gameOverTimerIn;

        MainMenu();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!isGameOver && !isMainMenu)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                GameOver();
            }

            countDownText.text = (int)timer + "s";
        }

        if (isGameOver)
        {
            gameOverTimer -= Time.deltaTime;

            if (gameOverTimer <= 0.0f)
            {
                SceneManager.LoadScene(0);
            }
        }

        if (isMainMenu)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                buttonPressed = true;
                mainMenuCountDownText.gameObject.SetActive(true);
                startGameText.gameObject.SetActive(false);
            }

            if(buttonPressed)
            {
                mainMenuTimer -= Time.deltaTime;

                mainMenuCountDownText.text = (int)mainMenuTimer + "";

                if (mainMenuTimer <= 0.0f)
                {
                    drinkText.SetActive(true);
                    mainMenu.SetActive(false);

                    player1.enabled = true;
                    player2.enabled = true;

                    isMainMenu = false;
                }
            }
        }
	}

    void GameOver()
    {
        isGameOver = true;
        gameOverMenu.SetActive(true);
        drinkText.SetActive(false);

        if (player1.drunkness == 0)
        {
            winnerText.text = "PLAYER 1 IS GOOD";
        }
        else if (player2.drunkness == 0)
        {
            winnerText.text = "PLAYER 2 IS GOOD";
        }

        if (player2.drunkness > 0 && player1.drunkness > 0)
        {
            winnerText.color = Color.red;
            winnerText.text = "DON'T DRINK, KIDS";
        }
        else
        {
            winnerText.text = "DON'T DRINK, KIDS";
        }

        player1.enabled = false;
        player2.enabled = false;
    }

    void MainMenu()
    {
        mainMenu.SetActive(true);
        drinkText.SetActive(false);

        player1.enabled = false;
        player2.enabled = false;
    }
}
