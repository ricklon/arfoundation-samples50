/*
 * First
 * Second
 * Third
 * 
 * We are not persons
 * We are people
 * 
 * I am all of these
 * and none
 * I follow, but at a distance
 * of one
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class toPerspectivize : Verb
{


    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("Select an object to follow by dragging it here")]
    public GameObject player ;

    [Tooltip("How much the object is offset in the x axis")]
    public float offsetX = 0f;

    [Tooltip("How much the object is offset in the y axis")]
    public float offsetY = 0f;

    [Tooltip("How much the object is offset in the z axis")]
    public float offsetZ = 0f;

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;



    //     The private variables
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    // this holds whether the verb has just played or not
    private bool justPlayed = false;



    //     The FixedUpdate Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void FixedUpdate()
    {
        if (isActive)
        {

            // This instantly sets the current position to that of the object defined in the inspector, with an additional predetermined offset
            transform.position = player.transform.position + new Vector3(offsetX, offsetY, offsetZ);

            justPlayed = true;
            
            if (!isActive && justPlayed)
            {         
                justPlayed = false;
                Activate(triggeredVerbs);
            }
        }
    }
}
//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * This positions one object relative to another, it can be used to set a camera at a fixed distance.  Combined with other verbs this can create useful relationships between objects.
 */
