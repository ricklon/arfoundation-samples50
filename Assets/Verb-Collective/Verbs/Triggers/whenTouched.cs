/*
* Just a gentle nudge will do
* tap, tickle, or touch 
* no matter how little 
* it does just as much
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whenTouched : Verb {



    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [SerializeField]
    [Tooltip("This is just for you to be aware of in the inspector")]
    private string Requirement1 = "One object with RigidBody";

    [SerializeField]
    [Tooltip("This is just for you to be aware of in the inspector")]
    private string Requirement2 = "Collider with isTrigger=True";

    [Tooltip("Turn this on if you only want the effect to happen once")]
    public bool happenOnlyOnce;

    [Tooltip("List of verbs you want to be triggered by this verb")]
    public Verb[] triggeredVerbs;



    //     The On Trigger Enter Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    // Checks for a collision with a trigger
    private void OnTriggerEnter(Collider other)
    {
        if(isActive)
        {

            Activate(triggeredVerbs);

            // If it has been set to only happen one time, turn off the verb
            if(happenOnlyOnce)
            {
                isActive = false;
            }
            
        }
    }

}
//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
* Triggers when object collides with another object
* User provides whether this objcet will deactive on touch
*/
