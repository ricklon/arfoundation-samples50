/*
 * They love me
 * They love me not
 * They love me
 * They love me not
 * 
 * Sometimes it is love
 * and sometimes it is you 
 * ripping apart flowers
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toRandomize : Verb
{




    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||
     



    [Tooltip("Set the percentage chance of triggering the verbs in the triggered verbs field")]      
    public float percentageChanceOfHappening = 1.0f;

    [Tooltip("Set the number of seconds you want to delay before 'rolling the dice', useful if it is repeating and active on start")]
    public float delay = 0.0f;

    [Tooltip("Set how many seconds will pass before 'rolling the dice' each time")]
    public float rate = 2.0f;

    [Tooltip("If you don't want the verbs to keep randomly triggering, select this")]
    public bool occurOnce = false;

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;

  

    //     The private variables
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||




    // This holds the number that test to see if the verbs are triggered or not
    private float randomValue;

    // this checks to see is the randomness function is already running
    private bool justPlayed;



    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void Update()
    {
        // if (the verb is active) and (justPlayed is NOT true)
        if (isActive && !justPlayed)
        {
            // This calls the roll dice function after a period of time (delay) and then again after (rate) number of seconds 
            InvokeRepeating("rollDice", delay, rate);

        }

        // if (the verb is NOT active)
        if (!isActive)
        {
            // This cancels the repeating function call and resets the justPlayed value
            CancelInvoke();
            justPlayed = false; 
        }

    }    



    //     The custom Roll Dice Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    // This function creates a random number and if that number is in the correct range it will trigger other verbs 
    void rollDice ()
    {
        // This just indicates that the function has been called so we can keep track of it
        justPlayed = true; 

        // This creates a random number between 0 and 100
        float randomValue = Random.Range(0.0f, 100.0f);

        // If (the random number is less than the percentage chance we set in the inspector)
        if (randomValue <= percentageChanceOfHappening)
        {

            Activate(triggeredVerbs);

            // If occur once is true
            if (occurOnce)
            {
                //cancel the invokation and turn off the verb
                CancelInvoke();
                isActive = false;
            }
        }
    }

}

//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * This verb is used to randomly trigger other verbs.  It can be used to create randomized behaivors and to induce chance to a scene or a process.
 */
