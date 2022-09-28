/*
 * I am nothing
 * you are nothing
 * we know nothing
 * nothing can be known
 * 
 * However...
 * It can still be helpful
 * To know why these scripts 
 * look the way they do
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * When you create a new verb 
 * it is important that the name 
 * of your script replaces 'toExample' below. 
 */
 
public class toExample : Verb
{



    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    /*
     * Public variables are visible and edittable
     * from within the inspector.  
     * This means that the same verb can be added 
     * to an object multiple times and do differnt things.
     * Public variables can also be accessed by external scripts
     */

    // The requirement string is used when there is a component or setting required for the verb to work and makes sure that it is visible at the top of the verb.
    [SerializeField]
    [Tooltip("The requirement field is just a private variable serialzed so that it is visible in the inspector.  It really just exists to make it easy to see at a glance if you need to do anything special for a verb to work")]
    private string requirement = "Make sure to add any components described here";

    [Tooltip("Any Verbs that you drag into this field will play after this action ends or is triggered")]
    public Verb[] triggeredVerbs;

    [Tooltip("Any Verbs that you drag into this field will stop playing after this action ends or is triggered")]
    public Verb[] verbsToDeactivate;



    //     The private variables
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||
     


    /*
     * Private variables are used in the script, 
     * but not visible in the inspector 
     * or accessible to other scripts.
     */

    // Booleans are variables that are always either true or false.  This one is often used to track whether a verb has already played or not.
    private bool justPlayed = false;



    //     The Start Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    /*
     * The Start function loads when the scene starts and is useful for initializing variables.
     * Some variables represent components, but they still need to be connected to those components while the program is running
     */

    private void Start()
    {

    }



    //     The Update or Fixed Update Function
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||



    /*
     * Your Verb will update every frame 
     * with this function. 
     * This is very important 
     * because it is how the script
     * actively looks for the inputs
     * that can cause it to trigger.
     * 
     * Note: If you are using a rigidbody
     * and moving things around with force
     * you might need to use FixedUpdate
     */

    void Update()
    {
        // If your verb is set to active the scripts below will run
        if (isActive)
        {

            /*
             * Verbs can be really simple,
             * as small as a single line of code,
             * Using verbs means you only 
             * need to write a tiny snippet
             * and that by combining it with 
             * other verbs you can create complexity.
             */

            //The Action of the Verb, what does it do?

            Debug.Log("I am");

            // Termination condition, when does it stop?
            // Many verbs that are instantaneous do not require any conditions

            /* The following if statement 
             * is just an example of a conditional statement
             * and should be replaced 
             * to match your desired conditions.
             * I added a second condition,
             * using &&, which means AND
             * 
             * - you don't need multiple conditions
             * - but I like you to know your options
             * - Such as && for (and), || for (or), ^ for (exclusive or) 
             * 
             * - also note that a boolean by itself means it is true (boolean)
             * - while a boolean with an ! in front means it is false (!boolean)
             * - so: (!boolean) is the same as (boolean == false) or (boolean != true)
             * 
             * - the difference between == and = is: 
             * - the former is checking a condition and the later is setting it
             * - use the former in conditional statements 
             * - use the latter to set values within a function
             *              
             * if all of the conditions are met
             * then any code within the {} brackets will run.
             */

            // if (variable1 == variable2 && otherCondition == conditionMet)
            //{

                // This sets the Verb variable isActive to false, essentially shutting it down
                isActive = false;

                // This triggers any verbs added to the triggered verbs array in the inspector
                Activate(triggeredVerbs);

                // This is used more rarely but can be very useful. This stops any verbs that were added to the verbs to deactivate array in the inspector
                Deactivate(verbsToDeactivate);

            //}
        }
    }
}
/*
 * This script is actually an important part of the documentation.  In going over the structure and common features of a verb, from within a verb, the goal is to make the information clearer and more accessible.
 */
