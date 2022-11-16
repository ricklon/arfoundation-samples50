using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class CountDownTimer : MonoBehaviour
{
    //Amount of time to count down from
    public float timeRemaining = 10;
    //Is timer running
    public bool timerIsRunning = false;
    //Text to display the time
    //unity ui textmeshpro text
    public TextMeshProUGUI timeText;
    


    void Start()
    {
        //start the timer
        timerIsRunning = true;
    }

    void Update()
    {
        //if the timer is running
        if (timerIsRunning)
        {
            //if the time is greater than 0
            if (timeRemaining > 0)
            {
                //decrease the time by 1
                timeRemaining -= Time.deltaTime;
                //display the time
                DisplayTime(timeRemaining);
            }
            else
            {
                //if the time is less than 0
                //stop the timer
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
        
    }
    //Display the time
    void DisplayTime(float timeToDisplay)
    {
        //if the time is greater than 0
        if (timeToDisplay > 0)
        {
            //convert the time to a string
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            //if the time is less than 0
            //display 00:00
            timeText.text = "00:00";

            //Do something when the timer is finished
            Debug.Log("Timer has finished");
        }
    }

    //reset the timer
    public void ResetTimer()
    {
        //reset the time
        timeRemaining = 10;
        //start the timer
        timerIsRunning = true;
    }
}
