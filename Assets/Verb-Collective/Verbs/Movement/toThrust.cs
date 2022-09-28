/*
 * May the force be with you
 * at least for a period of time
 * in the forward direction
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toThrust : Verb
{



    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("Determine how powerful the amount of thrust is")]
    public float power = 5.0f;

    public Verb[] triggeredVerbs;



    //     The private variables
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    // This declares the name for the rigidbody we will initialize in the start function
    private Rigidbody thisBody;

    // This Boolean is used to track where the verb has previously been triggered
    private bool justPlayed;



    //     The Start Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    private void Start()
    {
        // This initializes the variable we create up top, connecting it to this objects attributes
        thisBody = GetComponent<Rigidbody>();
    }



    //     The Fixed Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||
    // FixedUpdate is used when objects have or might have a Rigidbody
    // FixedUpdate is called once per frame



    void FixedUpdate()
    {

        if (isActive)
        {
            // We add force in the forward direction and multiply it by the power we selected in the inspector
            // ForceMode.Impulse means the force happens all at once in a burst
            thisBody.AddForce(transform.forward * power, ForceMode.Impulse);
            isActive = false;
        }


    }
}


//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * This verb applies a burst of force to the object, moving it in the direction it is facing.
 */
