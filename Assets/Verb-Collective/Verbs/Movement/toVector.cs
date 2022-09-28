/*
 * I like to move
 * ignoring all physics
 * I think im obsessed
 * with Cartesian Coordinates
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class toVector : Verb
{



    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("Drag the gameobject you want to have move here.  It will default to this object if left blank.")]
    public Transform objectToMove;

    [Tooltip("Movement in the X axis per frame, can be negative")]
    [Range( -1.0f, 1.0f)]
    public float rightward = 0f;
    
    [Tooltip("Movement in the y axis per frame, can be negative")]
    [Range(-1.0f, 1.0f)]
    public float upward = 0f;
    
    [Tooltip("Movement in the z axis per frame, can be negative")]
    [Range(-1.0f, 1.0f)]
    public float forward = 0f;

    [Tooltip("Multiplied by the direction to determine velocity")]
    public float speed = 20.0f;

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;



    //     The private variables
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    // Holds whether the verb has just played or not
    private bool justPlayed = false;



    //     The Start Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    private void Start()
    {
        if (objectToMove == null)
        {
            // Make this object the object to move
            objectToMove = this.gameObject.transform;
        }
    }



    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void Update()
    {
        if (isActive)
        {

            // This creates a vector 3 variable to hold the new vector comprised of the X Y and Z values selected in the inspector
            Vector3 direction = new Vector3(rightward, upward, forward);

            // Multiplying the speed by Time.deltaTime ensure smooth and consistent motion
            float step = speed * Time.deltaTime;

            // This moves the object in the selected direction, normalized to keep the speed consistent, moving at the spped selected in the browser
            objectToMove.Translate(direction.normalized * step);

            justPlayed = true;

        }

        // If this verb is NOT active AND it has just played
        if (!isActive && justPlayed)
        {
            isActive = false;
            Activate(triggeredVerbs);
        }
    }
}
//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * This verb ignores physics to move an object in line with a vector determined by the user.  Unlike toStep, this does not resolve at a predetermined distance.
 */
