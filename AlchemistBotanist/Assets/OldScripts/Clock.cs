using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour {

    public int time;
    public float timeScale = 1.0f;

    private Text timeText;


    // Use this for initialization
    void Start()
    {
        time = 0;
        timeText = GameObject.Find("TimeText").GetComponent<Text>();

    }

    void Tick()
    {
        time++;
        timeText.text = "Time: " + time;

    }

    public void startTimer()
    {
        InvokeRepeating("Tick", 0f, 1f / timeScale);
    }

    public void stopTimer()
    {
        CancelInvoke();
    }

    public void resetTimer()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
