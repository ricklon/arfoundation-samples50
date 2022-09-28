/*
 * If you want to move
 * towards some distant object,
 * The object might move
 * and you will move too
 * just watch out for walls
 * you cannot pass through
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toApproach : Verb
{



    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("This determines the speed the object will move")]
    public float speed = 1.0f;

    [Tooltip("Select this option to move towards a target game object")]
    public bool useTargetObject;

    [Tooltip("Drag the object you want to move towards here")]
    public Transform targetObject;

    [Tooltip("Select this option to move towards a target set of coordinates")]
    public bool useTargetPosition;

    [Tooltip("Choose the coordinates the object will move towards")]
    public Vector3 targetPosition;

    [Tooltip("Turn this on if you want the verb to end whenever it reaches the target object")]
    public bool StopOnArrival;

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;



    //     The private variables
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    // This holds the target location so that it is easier to figure out if the destination is reached.  Defaults to zero.
    private Vector3 target;

    // This is present to hold whether or not the verb has already triggered
    private bool justPlayed = false;



    //     The Fixed Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||


 
    void FixedUpdate()
    {
        if (isActive)
        {

            // if use target object has been selected
            if(useTargetObject)
            {
                // The target will become that objects current position
                target = targetObject.position;
            }

            // if use target position has been selected
            else if (useTargetPosition)
            {
                // The target will become the coordinates defined in the inspector
                target = targetPosition;
            }
            
            // step is a variable created to hold the velocity desired. Time.deltaTime is multiplied by the selected speed to make the motion consistent and smooth.
            var step = Time.deltaTime * speed;

            // Object will move from its current position, towards the target, at the correct speed.
            transform.position = Vector3.MoveTowards(transform.position, target, step);

            // If Stop on arrival is selected AND the current position is the same as the target position 
            if (StopOnArrival && transform.position == target)
            {
                isActive = false; 
            }

            justPlayed = true;
        }

        // If the verb is NOT active AND has just played
        if (!isActive && justPlayed)
        {
            justPlayed = false;
            Activate(triggeredVerbs);
        }
    }
}
/*
 * Object will move towards a target object or position at a variable speed. It can be set to trigger verbs and turn off upon arrival at a fixed destination or stay on continuously.
 */
