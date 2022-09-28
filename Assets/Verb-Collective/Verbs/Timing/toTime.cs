/*
 * I am looking at my wrist
 * but not wearing a watch
 * it just means I'm thinking
 * about how much time I've got
 * - you can use time to start
 * but also to stop
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toTime : Verb
{



    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("Determine how the timer will persist for")]
    public float duration = 3.0f;

    [Tooltip("At the end of the timer these verbs will chill (be set to isActive = False")]
    public Verb[] disableTheseVerbs;

    [Tooltip("At the end of the timer these verbs will trigger")]
    public Verb[] triggeredVerbs;



    //     The private variables
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    // This is a placeholder for setting increments of time, whenever time passes we add value to this variable
    private float timePassed;




    //     The Start Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    private void Start()
    {
        // when the script starts, it will set the timer to zero
        timePassed = 0.0f;
    }



    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void Update()
    {
        if (isActive)
        {
            //Time.deltaTime will increase the timePassed variable by time units instead of frames. This is useful because some computers are faster than others and this makes the experience more uniform
            timePassed += Time.deltaTime;

            //if (the time that has passed) is (greater than) the (duration you chose)
            if (timePassed >= duration)
            {
                //Deactivate this verb and activate the ones set to trigger at the end of the timer and then deactivate the ones in the disable these verbs field
                timePassed = 0.0f;
                isActive = false;
                Activate(triggeredVerbs);
                Deactivate(disableTheseVerbs);
            }

        }
    }
}

//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * Object will stay and wait for a duration of time
 * The user can provide the duration or it will be set to 3 as default.
 * This is useful for timing interactions and creating delays
 * Sometimes having a half second between functions helps avoid confusion
 * The difference between this and toWait is that this will also work to Disable Verbs
 */
