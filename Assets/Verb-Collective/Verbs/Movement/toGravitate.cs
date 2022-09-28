/*
 * The entire universe took shape
 * based on this simple principle 
 * now just imagine 
 * what you could do with it
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class toGravitate : Verb
{


    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("The speed at which 'planet' object will graviate toward 'sun' object")]
    public float gravitation = 5.0f;

    [Tooltip("Drag the object you want to move towards here")]
    public GameObject sun;

    [Tooltip("Drag the object you want to move here")]
    public GameObject planet;

    [Tooltip("Turn this on if you want the verb to end if the planet catches up to the sun")]
    public bool StopOnArrival;

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;



    //    The Private Variables 
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||


    // Hold the rigid body information for the moving object
    private Rigidbody planetBody;

    // This holds the direction that the planet needs to move in
    private Vector3 direction;

    // Hold the rigid body information for the destintation object
    private Rigidbody sunBody;

    // Defines whether the object just played or not
    private bool justPlayed = false;



    //     The Start Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    private void Start()
    {
        // This line of code initializes the following variable so that they can be accessed by our script
        planetBody = planet.GetComponent<Rigidbody>();
    }



    //     The FixedUpdate Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void FixedUpdate()
    {
        if (isActive)
        {

           
            // This creates the directional vector, by comparing the location of the two objects.  It is normalized so that it only contains directional information and not the magnitude
            direction = (sun.transform.position - planet.transform.position).normalized;

            // Adds a constant force to the planet in the direction of the sun, multiplied by Time.delta time to keep it consistent and smooth.
            planetBody.AddForce(direction * gravitation * Time.deltaTime);
           
            justPlayed = true;

            // If Stop on arrival is turned on AND the position of the sun and the position of the planet are the same.
            if (StopOnArrival && planet.transform.position == sun.transform.position)
            {
                isActive = false;
            }

        }

        // if it is NOT active AND has just played
        else if (!isActive && justPlayed)
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
 * Using physics, the 'planet' object will graviate toward the 'sun' object with a predetermined force
 */
