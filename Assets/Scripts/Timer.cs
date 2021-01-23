using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 12;
    public bool timerIsRunning = false;
    public Text timeText;
    public Text loseText;
    public Text infoText;
    public GameObject loseMusic;
    public GameObject infoMusic;
    public GameObject backgroundMusic;
    public GameObject cloak_final;
    public GameObject wall;
    public bool win = false;
    
    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        loseMusic.SetActive(false);
        infoMusic.SetActive(false);
        win = false;
    }

    void Update()
    {
        if (timerIsRunning)
        {
             if (timeRemaining > 9) //attempt
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
                
                info(); //attempt
            }
            else if (timeRemaining > 0 && timeRemaining < 10) //attempt
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
                infoMusic.SetActive(false); //attempt
                infoText.text = "";
                Destroy(wall);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;

                defeat();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
    }

    public void defeat()
    {
        loseText.text = "You Lose! Game created by Chase Rook.";
        backgroundMusic.SetActive(false);
        loseMusic.SetActive(true);
    }

    public void info() //attempt
    {
        infoText.text = "Use WASD to move! Pick up each object!";
        infoMusic.SetActive(true);
    }
}
