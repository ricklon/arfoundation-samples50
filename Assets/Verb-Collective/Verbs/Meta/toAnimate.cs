/*
* Think about Frankenstein,
* the creature not the man,
* it took lightning to animate him
* which was a complicated plan
* 
* If the dr had kept it simple 
* igor would not have failed so bad
* he could have set living to true
* and none would have gotten mad
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class toAnimate : Verb
{



    //     Public variables visible in inspector
    //________________________________________________
    //||||||||||||||||||||||||||||||||||||||||||||||||
     



    [SerializeField]
    [Tooltip("Just a heads up, so you know what this Verb needs in order to work, this is not creating or editting any timelines directly, it is using the mecanim system to turn animations on or off using common parameters")]
    private string requirement = "You need to have an animator created or this wont work.";
    
    [Tooltip("Drag your Animator into this field in order to control its parameters with this verb")] 
    public Animator myAnimation;

    [Tooltip("Precisely type the name of the parameter you want to change")]
    public string myParameter = "example";

    [Tooltip("Use a boolean parameter to control an animation")]
    public bool useBool = false;

    [Tooltip("Select what state you want your boolean paramenter to be in after triggering")]
    public bool boolParameter = true;

    [Tooltip("Use the Trigger parameter to control an animation")]
    public bool useTrigger = false;

    [Tooltip("Use a float based parameter to control animation")]
    public bool useFloat = false;

    [Tooltip("Set your float based parameter to this value")]
    public float floatParameter = 1.0f;

    [Tooltip("Use an integer based parameter to control animation")]
    public bool useInteger = false;

    [Tooltip("Set your integer based parameter to this value")]   
    public int integerParameter = 1;

    [Tooltip("Drag verbs into this field to have them trigger after this verb is played")] 
    public Verb[] triggeredVerbs;


    private void Start()
    {
        // This initializes the animator so that you can adjust its parameters
        myAnimation = GetComponent<Animator>();
    }

    void Update()
    {
        if (isActive)
        {
            // if using booleans
            if (useBool)
            {
                // This sets the parameter to be true or false based on bool you selected in the inspector
                myAnimation.SetBool(myParameter, boolParameter) ;
                isActive = false;
                Activate(triggeredVerbs);
            }

            // if using a trigger
            if (useTrigger)
            {
                // This sets off the trigger event
                myAnimation.SetTrigger(myParameter);
                isActive = false;
                Activate(triggeredVerbs);
            }

            // if using a float
            if (useFloat)
            {
                // set the value of your float based parameter to the one selected in the inspector
                myAnimation.SetFloat(myParameter, floatParameter);
                isActive = false;
                Activate(triggeredVerbs);
            }

            // if using an integer
            if (useInteger)
            {
                // set the value of your integer based parameter to the one selected in the inspector 
                myAnimation.SetInteger(myParameter, integerParameter) ;
                isActive = false;
                Activate(triggeredVerbs);
            }

        }
    }
}
/*
 * This verb leverages the basic parameters in the mecanim system to trigger animations.  You can select which type of parameter you want to use, and type the name of the parameter, then set it to whatever value you choose.
 */
