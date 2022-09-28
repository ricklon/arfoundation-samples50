/*
 * I didn't shoot the sheriff
 * or even the deputy
 * but I did skip out on tickets
 * for parking illegaly
 * 
 * If they know its me
 * When I try to leave
 * I will be arrested
 * and that will make me grieve
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whenFugitive : Verb   
{


    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [SerializeField]
    [Tooltip("This is just for you to be aware of in the inspector")]
    private string Requirement1 = "One object must have a RigidBody";

    [SerializeField]
    [Tooltip("This is just for you to be aware of in the inspector")]
    private string Requirement2 = "One collider has isTrigger set to true";

    [Tooltip("Turn this on if you only want the verb to happen once")]
    public bool deactivateOnTouch;

    [Tooltip("Correctly type the name of the object you want to test for")]
    public string nameBeingChecked = "Player";

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;



    //     The On Trigger Exit Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||




    // Checks to see if object hits another object
    void OnTriggerExit(Collider other)
    {            
        if (isActive)
            {
                // If the object you collided with has the name enter in the inspector
                if (other.gameObject.name == nameBeingChecked)
                {

                    Activate(triggeredVerbs);

                    // if deactivate on touch is turned on
                    if (deactivateOnTouch)
                    {
                        isActive = false;
                    }
                    
                }
            }
    }
}
//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * This verb triggers when the object exits a trigger collider attached to an object with the correct name.  An example of when you might use this is a player leaves a game area or exits a particular room. 
 */
