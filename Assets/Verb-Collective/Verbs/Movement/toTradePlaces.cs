/*
 * There was a movie in the 80's
 * With Eddie Murphy and Dan Ackroyd
 * that had a lot in common with this verb
 * only it referenced social class
 * rather than just the Verb class
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class toTradePlaces : Verb
{


    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [Tooltip("Drag the first object to swap here")]
    public Transform firstObject;

    [Tooltip("Drag the second object to swap here")]
    public Transform secondObject;

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;



    //    The Private Variables 
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    // Holds the current position of object 1
    private Vector3 object1position;

    // Holds the current position of object 2
    private Vector3 object2position;
    
    // This holds the status of the swapping process
    private bool swapping;


    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void Update()
    {
        if (isActive)
        {
            // if the positions have not yet started swapping
            if (!swapping)
            {
                // Find the current position of the objects and hold them in a variable
                object1position = firstObject.position;
                object2position = secondObject.position;

                // Show that the locations have started swapped
                swapping = true;

            } 
            //otherwise, if the positions are in the process of swapping
            else
            {
                // These two lines replaces the object's position with that of the other object
                firstObject.position = object2position;
                secondObject.position = object1position;

                // Show that the locations have already swapped
                swapping = false;

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
 * Makes two objects swap positions.
 */
