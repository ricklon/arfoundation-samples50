/*
 * Righty tighty
 * Lefty loosey
 * as long as it spins
 * this verb is happy
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toRotate : Verb
{


    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||


    [Tooltip("Drag the gameobject you want to make rotate here, leaving it blank defaults to this object")]
    public Transform rotatingObject;

    [Tooltip("Choose a number between 0 and 1 for each axis, with a higher number being used to select the axis for rotation.  Example (0,1,0) will rotate around the Y axis")]
    public Vector3 axis = Vector3.up;

    [Tooltip("This determines the speed at which it will rotate")]
    public float degreesPerSecond = 10.0f;

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;



    //    The Private Variables 
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||


    // This holds the information about whether the verb has just played or not
    private bool justPlayed = false;




    //     The Start Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||




    void Start()
    {
        // If the Object to rotate field was left blank
        if (rotatingObject == null)
        {
            // Make this object the object to rotate
            rotatingObject = this.gameObject.transform;
        }
    }


    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void Update()
    {
        if (isActive)
        {
            
            //Object will rotate against three variables, current position, user provided axis,
            //and user provided degreesPerSecond, multiplying by Time.deltaTime makes the motion smooth.
            rotatingObject.RotateAround(rotatingObject.position, axis, degreesPerSecond * Time.deltaTime);

            justPlayed = true;
            
        }

        // If it is NOT active AND it has just played
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
 * The object will rotate around an axis determined in the inspector at a given speed
 */
