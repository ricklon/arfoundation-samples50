/*
 * Life is a journey
 * that begins with a single step
 * so...
 * Use this verb
 * and enjoy the journey
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toStep : Verb
{



    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("Determine how fast you want the object to move")]
    public float speed = 1.0f;

    [Tooltip("Determine how far you want the object to move")]
    public float distance = 1.0f;

    [Tooltip("Movement in the X axis per frame, can be negative")]
    [Range( -1.0f, 1.0f)]
    public float rightward = 0f;
    
    [Tooltip("Movement in the y axis per frame, can be negative")]
    [Range(-1.0f, 1.0f)]
    public float upward = 0f;

    [Tooltip("Movement in the z axis per frame, can be negative")]
    [Range(-1.0f, 1.0f)]
    public float forward = 0f;



    public Verb[] triggeredVerbs;



    //     The private variables
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    // This Boolean is used to track where the verb has previously been triggered
    private bool justPlayed;

    // This holds the initial position of the object when it begins to move
    private Vector3 startPosition;

    // This holds whether the object has started moving or not
    private bool started = false;
    
    // This holds how much distance has traveled
    private float distanceTraveled;



    //     The Fixed Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||
    // FixedUpdate is used when objects have or might have a Rigidbody
    // FixedUpdate is called once per frame



    void FixedUpdate()
    {
        if (isActive)
        {

            // if movement has NOT started
            if (!started)
            {
                // Set the starting position and record that movement has begun
                startPosition = transform.position;
                started = true;
            }

            // This is a way to multiply the speed by a unit of time to make it run more smoothly and consistently across devices
            float step = speed * Time.deltaTime;

            // This moves the object relative to the directions defined in the inspector at the speed defined in the inspector
            transform.Translate(rightward * step, upward * step, forward * step);

            // Use the distance between the starting position and the current position to determine how far the object has moved
            distanceTraveled = Vector3.Distance(transform.position, startPosition);

            // If the distance traveled is MORE than the distance desired
            if (distanceTraveled >= distance)
            {
                //Stop the Verb and reset the started varieable back to false
                isActive = false;
                started = false;
            }

            justPlayed = true;

        }


        // if (is NOT currently active) AND (it was just triggered)
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
 * This moves an object, without using physics, in a direction of your choosing for a distance of your choosing.
 */
