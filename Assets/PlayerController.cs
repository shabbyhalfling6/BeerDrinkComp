using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject badText;
    public GameObject goodText;

    public GameObject HUD;

    public Transform player1Min;
    public Transform player1Max;
    public Transform player2Min;
    public Transform player2Max;

    private float timer = 0.0f;
    private float timerIn = 2.0f;


    private void Start()
    {
        timer = timerIn;
    }

    void Update ()
    {
        timer -= Time.deltaTime;

        PlayerInput();

        if(timer <= 0.0f)
        {
            if (drunkness == 0)
            {
                if (player1)
                {
                    Instantiate(goodText, new Vector2(Random.Range(player1Min.position.x, player1Max.position.x), Random.Range(player1Min.position.y, player1Max.position.y)), this.transform.rotation, HUD.transform);
                }
                else
                {
                    Instantiate(goodText, new Vector2(Random.Range(player2Min.position.x, player2Max.position.x), Random.Range(player2Min.position.y, player2Max.position.y)), this.transform.rotation, HUD.transform);
                }
            }
            timer = timerIn;
        }
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
                Instantiate(badText, new Vector2(Random.Range(player1Min.position.x, player1Max.position.x), Random.Range(player1Min.position.y, player1Max.position.y)), this.transform.rotation, HUD.transform);
            }
            else if (Input.GetKeyDown(KeyCode.S) && drink)
            {
                drink = false;
                drunkness++;
                spriteRendererS.sprite = empty;
                spriteRendererA.sprite = full;
                sKey.SetActive(false);
                aKey.SetActive(true);
                Instantiate(badText, new Vector2(Random.Range(player1Min.position.x, player1Max.position.x), Random.Range(player1Min.position.y, player1Max.position.y)), this.transform.rotation, HUD.transform);
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
                Instantiate(badText, new Vector2(Random.Range(player2Min.position.x, player2Max.position.x), Random.Range(player2Min.position.y, player2Max.position.y)), this.transform.rotation, HUD.transform);
            }
            else if(Input.GetKeyDown(KeyCode.L) && drink)
            {
                drink = false;
                drunkness++;
                spriteRendererL.sprite = empty;
                spriteRendererK.sprite = full;
                lKey.SetActive(false);
                kKey.SetActive(true);
                Instantiate(badText, new Vector2(Random.Range(player2Min.position.x, player2Max.position.x), Random.Range(player2Min.position.y, player2Max.position.y)), this.transform.rotation, HUD.transform);
            }
        }
    }
}
