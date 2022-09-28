/*
* Near or far
* wherever you go...
* I will be checking
* this verb lets me know
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whenDistant : Verb {



    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("If you want to use global coordinates")]
    public bool useCoordinates = false;

    [Tooltip("If you want to reference an object in your scene")]
    public bool useReferenceObject = false;

    [Tooltip("If you want to use your starting position")]
    public bool useInitialPosition = true;

    [Tooltip("This determines the coordinates to check your distance")]
    public Vector3 referenceCoordinates;

    [Tooltip("Drag a game object here to use it as a reference object for checking the distance")]
    public Transform referenceObject;

    [Tooltip("This determines how far away you need to be in order to trigger the script")]
    public float threshold;

    [Tooltip("Turn this on if you only want the trigger to activate a single time")]
    public bool triggerOnlyOnce;

    [Tooltip("Turn this on to invert the script and have it test to see if you are close enough to the reference location")]
    public bool triggerWhenNear;

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;




    //     The private variables
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    // This is holds initial position of the object 
    private Vector3 initialPosition;




    private void Start()
    {
        // sets the initial position to whatever your position is when the scene loads
        initialPosition = transform.position;
    }


    void Update () {

        if (isActive)
        {

            // NOTE: "^" is an operand for 'exclusive or', a logical operation that is true if and only if its arguments differ (one is true, the other is false)
            // it is used extensively below


            // If using coordinates
            if (useCoordinates)
            {
                // If (the distance between your current location and the reference coordinates defined in the inspector) is greater than (the threshold defined in the inspector) OR (it is false and you have turned on trigger when near)
                if (Vector3.Distance(transform.position, referenceCoordinates) > threshold ^ triggerWhenNear)
                {
                    Activate(triggeredVerbs);

                    if (triggerOnlyOnce)
                    {
                        isActive = false;
                    }
                }

            }
            // If using a reference object
            else if (useReferenceObject)
            {
                // If (the distance between your current location and the reference objects position) is greater than (the threshold defined in the inspector) OR (it is false and you have turned on trigger when near)
                if (Vector3.Distance(transform.position, referenceObject.position) > threshold ^ triggerWhenNear)
                {
                    Activate(triggeredVerbs);

                    if (triggerOnlyOnce)
                    {
                        isActive = false;
                    }
                }
            }
            // If using the objects starting position
            else if (useInitialPosition)
            {
                // If (the distance between your current location and your initial position) is greater than (the threshold defined in the inspector) OR (it is false and you have turned on trigger when near)
                if (Vector3.Distance(transform.position, initialPosition) > threshold ^ triggerWhenNear)
                {
                    Activate(triggeredVerbs);

                    if (triggerOnlyOnce)
                    {
                        isActive = false;
                    }
                }
            }

        }
    }
}
//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
* Triggers if the object is over a certain distance from point (or near to it). The point can either be set in inspector or will default to the starting location of the object. Users can provide the threshold as well as the target object. Users can also provide the option of this trigger occuring due to proximity and/or only triggering once.*/
