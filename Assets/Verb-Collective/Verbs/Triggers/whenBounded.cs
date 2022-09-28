/*
 * I like to go there
 * I like to to seek
 * if I keep going 
 * my prospects are bleak
 * 
 * if I stay local 
 * and don't go too far
 * I can ignore this verb
 * and lower my bar
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class whenBounded : Verb
{



    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("Select the height of the bounded area")]
    public float boundaryTop = 15.0f;
    [Tooltip("Select the floor of the bounded area")]
    public float boundaryBottom = -15.0f;
    [Tooltip("Select the leftmost extent of the bounded area")]
    public float boundaryLeft = -15.0f;
    [Tooltip("Select the rightmost extent of the bounded area")]
    public float boundaryRight = 15.0f;
    [Tooltip("Select the distance forward of the bounded area")]
    public float boundaryFront = 15.0f;
    [Tooltip("Select the distance backwards of the bounded area")]
    public float boundaryBack = -15.0f;

    [Tooltip("If this is turned on the verb will trigger other verbs when the boundary is reached")]
    public bool triggerAtBorder = false;

    [Tooltip("Select this if the object should be destroyed on exiting the boundary")]
    public bool destroyOnExit = false;

    [Tooltip("List of verbs you want to be triggered by this verb")]
    public Verb[] triggeredVerbs;



    //     The private variables
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    // this holds the value of whether the verb was just triggered or not
    private bool justPlayed = false;



    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void Update()
    {
        if (isActive)
        {

            justPlayed = true;

            // If destroy on exit is NOT turned on
            if (!destroyOnExit)

            {
                //If the object goes past the boundary, it teleports to the edge of the boundary
                if (transform.position.x < boundaryLeft)
                {
                    // If Trigger At Border is turned on, AND there are verbs to trigger, activate verbs, otherwise send this object back to the border
                    if (triggerAtBorder && triggeredVerbs != null )
                    {
                        Activate(triggeredVerbs);
                    } else
                    transform.position = new Vector3(boundaryLeft, transform.position.y, transform.position.z);
                }

                //If the object goes past the boundary, it teleports to the edge of the boundary
                if (transform.position.x > boundaryRight)
                {
                    // If Trigger At Border is turned on, AND there are verbs to trigger, activate verbs, otherwise send this object back to the border
                    if (triggerAtBorder && triggeredVerbs != null )
                    {
                        Activate(triggeredVerbs);
                    } else
                    transform.position = new Vector3(boundaryRight, transform.position.y, transform.position.z);
                }

                //If the object goes past the boundary, it teleports to the edge of the boundary
                if (transform.position.y < boundaryBottom)
                {
                    // If Trigger At Border is turned on, AND there are verbs to trigger, activate verbs, otherwise send this object back to the border
                    if (triggerAtBorder && triggeredVerbs != null )
                    {
                        Activate(triggeredVerbs);
                    } else
                    transform.position = new Vector3(transform.position.x, boundaryBottom, transform.position.z);
                }

                //If the object goes past the boundary, it teleports to the edge of the boundary
                if (transform.position.y > boundaryTop)
                {
                    // If Trigger At Border is turned on, AND there are verbs to trigger, activate verbs, otherwise send this object back to the border
                    if (triggerAtBorder && triggeredVerbs != null )
                    {
                        Activate(triggeredVerbs);
                    } else
                    transform.position = new Vector3(transform.position.x, boundaryTop, transform.position.z);
                }

                //If the object goes past the boundary, it teleports to the edge of the boundary
                if (transform.position.z < boundaryBack)
                {
                    // If Trigger At Border is turned on, AND there are verbs to trigger, activate verbs, otherwise send this object back to the border
                    if (triggerAtBorder && triggeredVerbs != null )
                    {
                        Activate(triggeredVerbs);
                    } else
                    transform.position = new Vector3(transform.position.x, transform.position.y, boundaryBack);
                }

                //If the object goes past the boundary, it teleports to the edge of the boundary
                if (transform.position.z > boundaryFront)
                {
                    // If Trigger At Border is turned on, AND there are verbs to trigger, activate verbs, otherwise send this object back to the border
                    if (triggerAtBorder && triggeredVerbs != null )
                    {
                        Activate(triggeredVerbs);
                    } else
                    transform.position = new Vector3(transform.position.x, transform.position.y, boundaryFront);
                }
            }

            // If destroy on exit is turned on
            if (destroyOnExit)

            {
                // NOTE: typing "|" is like saying 'or' 
                // If the object goes past any of the the boundary edges, it ends the verb and destroys the object
                if (transform.position.x < boundaryLeft | transform.position.x > boundaryRight | transform.position.y < boundaryBottom | transform.position.y > boundaryTop | transform.position.z < boundaryBack | transform.position.z > boundaryFront)
                {
                    isActive = false;
                    Activate(triggeredVerbs);
                    Destroy(gameObject);
                }
            }
        }

        // If (the verb is NOT active) AND (the verb has just played)
        if (!isActive && justPlayed)
        {
           Activate(triggeredVerbs);
           justPlayed = false;
        }        
    }
}
//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * This verb is used to keep an object in a predefined space.  It can be useful for getting rid of unwanted objects or for creating a constrained play area.
 */
