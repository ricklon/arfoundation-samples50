/*
 * Sometimes im willing 
 * to do something for you
 * but I like to make sure
 * that you're really you
 * 
 * If you are the one
 * Then you have the right name
 * otherwise just forget it
 * I wont do a thing
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toSubpoena : Verb
{


    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [SerializeField]
    [Tooltip("This is just for you to be aware of in the inspector")]
    private string Requirement1 = "One object with RigidBody";

    [SerializeField]
    [Tooltip("This is just for you to be aware of in the inspector")]
    private string Requirement2 = "Collider with isTrigger=True";
    
    [Tooltip("Turn this on if you only want the verb to happen once")]
    public bool deactivateOnTouch;

    [Tooltip("Select if you want to check for the name before triggering verbs")]
    public bool useName = true;

    [Tooltip("Correctly type the name you want to test for")]
    public string nameBeingChecked = "Player";

    [Tooltip("Select if you want to check for tags before triggering verbs")]
    public bool useTag = false;

    [Tooltip("Correctly type the tag you want to test for")]
    public string tagBeingChecked = "Player";

    public Verb[] triggeredVerbs;



    //     The OnTriggerEnter Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    // Checks to see if object hits another object
    void OnTriggerEnter(Collider other)
    {
        //If the name of the other object that was collided with is the one written in the inspector AND/OR the other object has the tag defined in the inspector 
        if (other.gameObject.name == nameBeingChecked || other.gameObject.tag == tagBeingChecked)
        {
            if (isActive)
            {
                Activate(triggeredVerbs);

                //If deactivate on touch has been selected
                if (deactivateOnTouch)
                {
                    isActive = false;
                }
                    
            }
        }
    }

}//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * This verb looks for trigger collisions and will then trigger verbs if the triggering object has the correct name
 */
