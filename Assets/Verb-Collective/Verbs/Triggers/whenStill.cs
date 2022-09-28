/*
* Motion gets all the love
* everyone wants to move
* but if you can handle stillness
* this verb will play your tune
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whenStill : Verb {



    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("Determine how the long the object needs to be still for")]
    public float duration = 3.0f;

    [Tooltip("Check this if you only want this to happen once")]
    public bool triggerOnlyOnce;

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;



    //     The private variables
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [SerializeField]
    [Tooltip("This holds the amount of time passed, it is visible in the inspector to help figure out settings and timing")]
    private float timePassed = 0.0f;



    //     The Fixed Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||
    //FixedUpdate is often used when objects are given Rigidbody in Unity




    void FixedUpdate()
    {
        if (isActive)
        {

            // if any movement occurs 
            if (transform.hasChanged)
            {
                // Reset timer and the 'hasChanged' value
                timePassed = 0.0f;
                transform.hasChanged = false;
            }

            else
            {
                // if (Time Passed is more than the duration defined in the inspector) AND (this is set to only trigger once)
                if (timePassed >= duration && triggerOnlyOnce)
                {
                    // turn off the verb, reset the timer, and activate the verbs
                    isActive = false;
                    timePassed = 0.0f;
                    Activate(triggeredVerbs);
                }
                // if (Time Passed is more than the duration defined in the inspector)
                else if (timePassed >= duration)
                {
                    // Reset the timer and trigger any verbs
                    timePassed = 0.0f;
                    Activate(triggeredVerbs);
                }
                // if (Time Passed is less than the duration defined in the inspector)
                else if(timePassed <= duration)
                {
                    // sets the timer to run
                    timePassed += Time.deltaTime;
                }
            }
        }
    }
}
//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
* Triggers when object remains motionless for a duration of time. User provides the duration for the object to remain still
*/
