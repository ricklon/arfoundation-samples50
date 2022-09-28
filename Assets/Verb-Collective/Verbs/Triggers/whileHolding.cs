/*
 * He's got the whole world in his hands
 * the whole world in his hands
 * 
 * but most of the time
 * it's just one object 
 * and if it is this object,
 * with this verb,
 * ...something might happen...
 * then stop once you let go
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whileHolding : Verb {



    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||


    [SerializeField]
    [Tooltip("This is just for you to be aware of in the inspector")]
    private string Requirement1 = "One object with RigidBody";

    [SerializeField]
    [Tooltip("This is just for you to be aware of in the inspector")]
    private string Requirement2 = "Collider with isTrigger=True";

    [Tooltip("List of verbs you want to be triggered by this verb")]
    public Verb[] triggeredVerbs;



    //     The OnTriggerEnter Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    // Checks to see if object hits another object with a trigger collider
    private void OnTriggerEnter(Collider other)
    {
        if (isActive)
        {
            Activate(triggeredVerbs);
        }
    }



    //     The OnTriggerExit Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    // Checks to see if object exits a collision with another object that has a trigger collider
    private void OnTriggerExit(Collider other)
    {
        if (isActive)
        {
            Deactivate(triggeredVerbs);
        }
    }
}
//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
* Triggers when trigger object is collided with, it then deactivates any verbs when it exits that collison.  It does require one object to have a rigidBody and one object's collider to be set as a trigger.
*/
