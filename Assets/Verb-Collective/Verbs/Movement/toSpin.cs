/*
 * Some people rotate 
 * some people spin
 * the way I do it
 * plays to win
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class toSpin : Verb
{



    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    [SerializeField]
    [Tooltip("This is just here to let you know of any requirements")]
    private string requirement = "This uses Unity's input system, so it might conflict with similiar scripts";

    [Tooltip("This determines how fast the object will spin")]
    public float rotationSpeed = 40.0f;

    [Tooltip("Choose a number between 0 and 1 for each axis, with a higher number being used to select the axis for rotation.  Example (0,1,0) will rotate around the Y axis")]
    public Vector3 axis = Vector3.up;

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;



    //     The private variables
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    // This holds the values coming from Unity's input system
    private float horizontalInput;

    // This hold whether the verb has just played
    private bool justPlayed = false;



    //     The Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void Update()
    {
        if (isActive)
        {

            // Both of these declarations connect the horizontalInput to Unity's input system.  This means they will return a value between -1 and 1, that transitions smoothly, based on a variety of key presses or controller inputs
            // This in the update function rather than the fixed update function because we want the inputs to get a response before the animations are updated.
            horizontalInput = Input.GetAxis("Horizontal");
        }
    }



    //     The Fixed Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    void FixedUpdate()
    {
        if (isActive)
        {

            // This rotates along the selected axis, multipyling your speed by the input value, and also multiplying by Time.deltaTime to ensure smooth motion
            transform.Rotate(axis, horizontalInput * rotationSpeed * Time.deltaTime);

            justPlayed = true;
 
        }  

        // If the verb is NOT active AND it has just played
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
 * Similiar to "to Rotate" this option uses Unity's input system and is included because for people exploring games or keyboard based experiences, it is useful to have shorthand ways to access the built in input system.
 */
