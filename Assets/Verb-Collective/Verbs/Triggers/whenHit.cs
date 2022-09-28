/*
 * Ouch! 
 * It isnt nice to hit people,
 * or things,
 * but sometimes it happens
 * and when it does
 * it can trigger some verbs
 */ 
   
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whenHit : Verb {




    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [SerializeField]
    [Tooltip("This is just for you to be aware of in the inspector")]
    public string Requirement1 = "One object must have RigidBody";

    [SerializeField]
    [Tooltip("This is just for you to be aware of in the inspector")]
    public string Requirement2 = "Collider has 'is trigger' set to false";

    [Tooltip("Check this if you only want this to happen once")]
    public bool triggerOnlyOnce;

    [Tooltip("List of verbs you want to be triggered by this verb")]
    public Verb[] triggeredVerbs;



    //     The OnCollisonEnter Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    // This function runs whenever there is a collison
    private void OnCollisionEnter(Collision collision)
    {
        if (isActive)
        {
            Activate(triggeredVerbs);

            // If you have set it to only happen once
            if (triggerOnlyOnce)
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
* Triggers when object collides with another object. Requires a collider with the isTrigger property set to false
*/
