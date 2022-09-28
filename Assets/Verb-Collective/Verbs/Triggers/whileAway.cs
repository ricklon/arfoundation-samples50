/*
* Absence 
* makes the heart grow fonder
* Distance 
* just triggers this verb
* - until you leave again
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whileAway : Verb {



    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("This determines the location being referenced by the script, blank is simply your starting position")]
    public Vector3 point;
     
    [Tooltip("This determines how far away you need to be in order to trigger the script")]
    public float threshold;

    [Tooltip("Turn this on to invert the script and have it test to see if you are close enough to the reference location")]
    public bool triggerWhenNear;

    [Tooltip("Turn this on if you only want the trigger to activate a single time")]
    public bool triggerOnlyOnce;

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;



    //     The private variables
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    // this holds whether the verb has triggered yet
    private bool justPlayed = false;





    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void Update () 
    {

        if (isActive)
        {
            

            // "^" is an operand for 'exclusive or', a logical operation that is true if and only if its arguments differ (one is true, the other is false)
            // If (the distance between your current location and the point defined in the inspector) is greater than (the threshold defined in the inspector) OR (it is false and you have turned on trigger when near)
            if (Vector3.Distance(transform.position, point) > threshold ^ triggerWhenNear)
            {
                // if justPlayed is NOT true
                if (!justPlayed)
                {

                    Activate(triggeredVerbs);

                    // if trigger only one is turned on
                    if (triggerOnlyOnce)
                    {
                        isActive = false;
                    }

                    justPlayed = true;
                }
            }
            else
            {
                //if justPlayed is true
                if (justPlayed)
                {

                    Deactivate(triggeredVerbs);
                    justPlayed = false;
                }
            }   
        }
    }
}
//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
* Triggers if the object is over distance from a point that can be set in inspector, or else it will default to the starting point. The user can provide the threshold and the location(point). User can also provide the option of this trigger occuring due to proximity and/or only triggering once.
*/
