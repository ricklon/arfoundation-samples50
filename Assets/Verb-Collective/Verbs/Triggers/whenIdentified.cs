/*
 * It isn't love 
 * if it is for everyone
 * this verb is special
 * - just for you -
 * if your name is nameBeingChecked
 * and useName is true
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whenIdentified : Verb
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

    [Tooltip("Turn this on if you only want the verbs to only trigger once")]
    public bool happenOnce = false;

    [Tooltip("Turn this to look for objects by name")]
    public bool useName = false;

    [Tooltip("Turn this to look for objects by tag")]
    public bool useTag = true;

    [Tooltip("Correctly type the name of the tag you want to test for")]
    public string tagBeingChecked = "Player";

    [Tooltip("Correctly type the name of the object you want to test for")]
    public string nameBeingChecked = "Player";

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;




    //     The OnTriggerEnter Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||





    // Checks to see if object hits another object
    void OnTriggerEnter(Collider other)
    {
        // If the verb is active and use name is being used
        if (isActive && useName)
        {
            // If the name of the other object is the one added in the inspector 
            if (other.gameObject.name == nameBeingChecked)
            {
                Activate(triggeredVerbs);

                // If the verb is set to only happen once before deactivating
                if (happenOnce)
                {
                    isActive = false;
                }
            }


        }

        // If the verb is active and use tag is being used
        if (isActive && useTag)
        {
            // If the tag of the other object is the one added in the inspector 
            if (other.gameObject.tag == tagBeingChecked)
            {
                Activate(triggeredVerbs);

                // If the verb is set to only happen once before deactivating
                if (happenOnce)
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
 * This verb looks for trigger collisions and, depending on whether the colliding object has the correct name or tag it will trigger an effect.
 */
