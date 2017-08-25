using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContoller : MonoBehaviour {

    private float timer = 0.0f;
    public float timerIn = 40.0f;

    public GameObject gameOverMenu;
    public GameObject mainMenu;

	// Use this for initialization
	void Start ()
    {
        timer = timerIn;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            GameOver();
        }
	}

    void GameOver()
    {
        Time.timeScale = 0.0f;
        gameOverMenu.SetActive(true);
        //set game over screen to true and pause the game
    }

    void MainMenu()
    {
        mainMenu.SetActive(true);
        //set the main menu to true and pause the game
    }
}
