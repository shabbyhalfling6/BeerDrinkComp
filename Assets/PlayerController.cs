using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public bool player1 = true;

    public bool drink = false;

    public int drunkness = 0;

    public GameObject aKey;
    public GameObject sKey;
    public GameObject kKey;
    public GameObject lKey;

    public SpriteRenderer spriteRendererA;
    public SpriteRenderer spriteRendererS;
    public SpriteRenderer spriteRendererK;
    public SpriteRenderer spriteRendererL;

    public Sprite full;
    public Sprite empty;

	
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
                spriteRendererA.sprite = empty;
                spriteRendererS.sprite = full;
                aKey.SetActive(false);
                sKey.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.S) && drink)
            {
                drink = false;
                drunkness++;
                spriteRendererS.sprite = empty;
                spriteRendererA.sprite = full;
                sKey.SetActive(false);
                aKey.SetActive(true);
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.K) && !drink)
            {
                drink = true;
                drunkness++;
                spriteRendererK.sprite = empty;
                spriteRendererL.sprite = full;
                kKey.SetActive(false);
                lKey.SetActive(true);
            }
            else if(Input.GetKeyDown(KeyCode.L) && drink)
            {
                drink = false;
                drunkness++;
                spriteRendererL.sprite = empty;
                spriteRendererK.sprite = full;
                lKey.SetActive(false);
                kKey.SetActive(true);
            }
        }
    }
}
