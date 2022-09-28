/*
 * Think of the sun,
 * then the planets 
 * and moons
 * 
 * They all circle around
 * one thing or another
 * whether galaxies afar
 * or even each other
 * 
 * Pick something to circle
 * and use this verb
 * - you'll feel super celestial
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toOrbit : Verb {



    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("Drag the gameobject you want to orbit here")]
    public Transform target;

    [Tooltip("Choose a number between 0 and 1 for each axis, with a higher number being used to select the axis for rotation")]
    public Vector3 axis = Vector3.up;

    [Tooltip("Choose the speed at which to orbit the target object")]
    public float speed = 10.0f;

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;



    //    The Private Variables 
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||


    // Hold whether the verb has already played or not
    private bool justPlayed;




    //     The Fixed Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void FixedUpdate () {

		if(isActive)
		{
            
            
            //Each time FixedUpdate() runs the object's position will update based on its current position,
            //the axis provided, and the speed. Multiplying the speed by Time.deltaTime will provide a smooth transition.
            transform.RotateAround(target.position, axis, speed * Time.deltaTime);

            justPlayed = true;

            

        }
        if (!isActive && justPlayed)
        {
            justPlayed = false;
            Activate(triggeredVerbs);
        }
    }
}
//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * Object will orbit around a target object at a variable speed. User will set the speed, as well as both the satellite object and the one that it orbits. User can select the axis as well, but defaults to orbiting on the y-axis.
 */
