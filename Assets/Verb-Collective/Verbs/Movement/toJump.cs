/*
* You know Mario
* I know Mario
* we all know Mario,
* we even know Luigi
* 
* The reason we know them 
* is because of me,
* I am the force
* that was with them
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toJump : Verb
{


    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||


    [SerializeField]
    [Tooltip("This is just to let you know of any valid requirements")]
    private string Requirement = "This uses a rigidbody and physics, adjust drag, angular drag, and mass to get the right feel";

    [Tooltip("what do you want to make the Jump, it will default to this object if left empty")]
    public GameObject jumper;

    [Tooltip("How much force will it have when it jumps")]
    public float force = 10.0f;

    [Tooltip("Choose a number between -1 and 1 for each axis, this determines the direction of the jumping force.  Example: (0,1,0) will jump upwards in the Y axis, (0,0,-1) will jump backwards in the Z axis")]
    public Vector3 jumpDirection = Vector3.up;
   
    public Verb[] triggeredVerbs;



    //    The Private Variables 
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    private Rigidbody jumperBody;



    //     The Start Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    private void Start()
    {
        // If the jumper field was left blank
        if (jumper == null)
        {
            // Make this object the jumper
            jumper = this.gameObject;
        }

        // This initializes the jumperBody variable so that we can access its components
        jumperBody = jumper.GetComponent<Rigidbody>();
    }



    //     The FixedUpdate Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    private void FixedUpdate()
    {
        
        if (isActive)
        {
            
            // Add force to the jumping object in the direction determined in the inspector (normalized to keep the force consistent). Using the force mode of impulse has the force get applied in a burst.        
            jumperBody.AddForce(jumpDirection.normalized * force, ForceMode.Impulse);
           
            isActive = false;
            Activate(triggeredVerbs);
        }

    }
}
//     Verb Description Below
//________________________________________________
//||||||||||||||||||||||||||||||||||||||||||||||||
/*
 * Causes the 'jumper' object to move in the designated direction with the applied amount of force.
 */
