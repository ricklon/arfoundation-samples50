/*
 * Home is where the heart is
 * and as far as you go
 * you can always go home
 * 
 * This verb brings you back
 * to where you began
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toReturn : Verb {



    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("Choose how fast you want it to return to the origin")]
    public float returnRate = 5.0f;

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;



    //     The private variables
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    // These variables are to hold the initial position of the object, so that it can return later
    private Vector3 startingPosition;
    private Quaternion startingRotation;



    //     The Start Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    private void Start()
    {

        //Sets both startingPosition and startingRotation before any transformations occur
        startingPosition = this.transform.position;
        startingRotation = this.transform.rotation;

        //Makes sure it is off when it starts, because you cannot return to where you already are...
        this.isActive = false;

    }



    //     The Fixed Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||
    // FixedUpdate is used when objects have or might have a Rigidbody
    // FixedUpdate is called once per frame



    void FixedUpdate () {

		if(isActive)
		{

            //Multiplying by Time.detlaTime uses time rather than framrate for animations
            float step = returnRate * Time.deltaTime;
            //Updates the position of the object to move closer to the place of origin(startingPosition)
            transform.position = Vector3.MoveTowards(transform.position, startingPosition, step);
            //Keeps the object from rotating beyond the scope of the target object
            transform.rotation = Quaternion.RotateTowards(transform.rotation, startingRotation, 30.0f * step);


            // if (The current position is equal to the starting position AND the current rotation is equal to the starting rotation)
            if (this.transform.position == startingPosition && this.transform.rotation == startingRotation)
            {
                isActive = false;
                Activate(triggeredVerbs);
            }
        }
    }
}


//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * Object will return to place of origin when triggered, you can set the speed using the return rate.
 */
