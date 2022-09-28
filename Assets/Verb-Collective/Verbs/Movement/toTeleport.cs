/* 
 * This verb might be
 * the solution
 * to the Santa paradox
 * 
 * There are no reindeers, 
 * only this script
 * 
 * And Santa uses it
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toTeleport : Verb {



    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("If you want to use global coordinates")]
    public bool useCoordinates = false;

    [Tooltip("Choose the location that you want to teleport to")]
    public Vector3 targetPos;

    [Tooltip("If you want to teleport to the location of the GameObject selected above")]
    public bool useReferenceObject = false;

    [Tooltip("Select a GameObject to teleport to")]
    public Transform teleportTarget;

    [Tooltip("If you want to return to your initial location after having moved, select this option")]
    public bool useInitialPosition = true;

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;



    //     The private variables
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    private Vector3 initialPosition;



    //     The Start Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    private void Start()
    {
       // This sets the value of initialPosition to whatever your position is when the scene loads
       initialPosition = transform.position;
    }



    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void Update () {

		if(isActive)
		{
            // if using coordinates
            if (useCoordinates)
            {
                // your transform is equal to the coordinates set in the inspector
                this.transform.position = targetPos;

            }
            // if using a reference object
            else if (useReferenceObject)
            {
                // your transform is equal to the position of the reference object you selected
                this.transform.position = teleportTarget.transform.position;
            }
            // if using the objects initial position
            else if (useInitialPosition)
            {
                // return to the initial position you had when the scene started
                this.transform.position = initialPosition;
            }

            isActive = false;
            Activate(triggeredVerbs);
		}
	}	
}
//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/* 
 * Object will instantly move its position to a target position. The user can decide if this movement uses a set of coordinates, a reference object, or if it simply returns to its initial position.
 */
