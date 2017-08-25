using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public bool player1 = true;

    public bool drink = false;

    public int drunkness = 0;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	void Update ()
    {
        PlayerInput();
	}

    void PlayerInput()
    {
        if (player1)
        {
            if (Input.GetKeyDown(KeyCode.A) && !drink)
            {
                drink = true;
                drunkness++;
                DrinkADrink();
            }
            else if (Input.GetKeyDown(KeyCode.S) && drink)
            {
                drink = false;
                drunkness++;
                DrinkADrink();
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.K) && !drink)
            {
                drink = true;
                drunkness++;
                DrinkADrink();
            }
            else if(Input.GetKeyDown(KeyCode.L) && drink)
            {
                drink = false;
                drunkness++;
                DrinkADrink();
            }
        }
    }

    void DrinkADrink()
    {
        //make the sprite change here
    }
}
