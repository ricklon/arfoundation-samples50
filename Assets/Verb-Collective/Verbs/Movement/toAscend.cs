/*
 * Heat rises up
 * up to towards the sky
 * when this gets triggered
 * so do I
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toAscend : Verb {



    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("Choose how fast the object will rise")]
    public float rate = 1.0f;

    [Tooltip("Choose the height that it will stop ascending, or descending, at")]
    public float maxHeight = 20.0f;

    [Tooltip("Select this to descend rather than ascend")]
    public bool descendInstead;

    public Verb[] triggeredVerbs;



    //     The Fixed Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||

    //FixedUpdate is used when objects are given Rigidbody in Unity
    // FixedUpdate is called once per frame



    void FixedUpdate()
    {
        if (isActive)
        {

            /*
             * Vector3.up is shorthand. You can replace up with right, left, or down to change direction.
             */
            
            // If descendInstead is NOT true
            if (!descendInstead)
            {
                // Take the current position and add to it in the up direction, multiplied by your selected rate.  Time.deltaTime is used to make the timing consistent across platforms
                transform.position += Vector3.up * rate * Time.deltaTime;
                
                // if the position is greater than the maximum height, resolve the verb
                if (transform.position.y >= maxHeight)
                {
                    EndVerb();
                    Activate(triggeredVerbs);   
                }
            }

            // If descendInstead is true
            if (descendInstead)
            {
                // Take the current position and add to it in the down direction, multiplied by your selected rate.  Time.deltaTime is used to make the timing consistent across platforms
                transform.position += Vector3.down * rate * Time.deltaTime;
                
                // if the position is less than the maximum height, resolve the verb
                if (transform.position.y <= maxHeight)
                {
                    EndVerb();
                    Activate(triggeredVerbs);   
                }
            }


            
        }
    }
}
//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * Object will move up on the y-axis at a variable speed to a max height.  The speed and height are the main variables for this verb.  The verb will end when the object reaches or exceeds the max height.  This will work to descend as well is negative numbers are used
 */
