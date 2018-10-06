using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour {

    public Clock clock;
    public GameObject player;
    private GameObject playerClone;
    

    private GameObject levelImage;
    public bool doingSetup = true;
    private Text dayText;

    private int day = 1;
    private float levelStartDelay = 2.0f;

	// Use this for initialization
	void Awake () {
        doingSetup = true;
        levelImage = GameObject.Find("LevelImage");
        dayText = GameObject.Find("DayText").GetComponent<Text>();
        clock = GameObject.Find("Clock").GetComponent<Clock>();

        Invoke("HideLevelImage", levelStartDelay);
        InitGame();
	}

    void HideLevelImage()
    {
        levelImage.SetActive(false);
        doingSetup = false;
        clock.startTimer();
    }

    void InitGame()
    {
        Instantiate(player);
        playerClone = GameObject.Find("Player(Clone)");

    }

    //Stops the last Day and initializes a new Day
    public void InitDay()
    {
        clock.stopTimer();
        clock.resetTimer();
        doingSetup = true;
        levelImage.SetActive(true);
        playerClone.transform.position = Vector3.zero;
        Transform test = playerClone.transform;
        day++;
        dayText.text = "Day: " + day;
        
        Invoke("HideLevelImage", levelStartDelay);
    }

    void passOut()
    {
        if (clock.time >= 60)
        {
            InitDay();
        }
    }


	
	// Update is called once per frame
	void Update () {
        passOut();
	}
}
